using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SRS_Game.Data;
using SRS_Game.Interfaces;
using SRS_Game.Models;

namespace SRS_Game.Controllers
{
    [Authorize(Policy = "AdministratorPolicy")]
    public class UsersController : Controller
    {
        private readonly SRS_GameDbContext _context;

        private readonly IReadableUser _readableUser;

        private readonly PasswordHasher<User> _passwordHasher;

        public UsersController(SRS_GameDbContext context, IReadableUser readableUser)
        {
            _context = context;
            _readableUser = readableUser;
            _passwordHasher = new PasswordHasher<User>();
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users
                .Include(u => u.Roles)
                .Select(u => new UserIndexViewModel
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Login = u.Login,
                    PhoneNumber = u.PhoneNumber,
                    Roles = string.Join(",", u.Roles.Select(r => r.Name))
                })
                .ToListAsync();

            return View(users);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int id)
        {
            //var user = _readableUser.GetUserDetailsByIdAsync(id);

            var user = await _context.Users
                .Where(u => u.Id == id)
                .Include(u => u.Roles)
                .Select(u => new UserIndexViewModel
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Login = u.Login,
                    PhoneNumber = u.PhoneNumber,
                    Roles = string.Join(",", u.Roles.Select(r => r.Name))
                })
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            var viewModel = new UserCreateViewModel
            {
                AvailableRoles = _readableUser.GetUserRolesForSelectList()
            };

            return View(viewModel);
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Login,Email,PhoneNumber,Password,ConfirmPassword,SelectedRoleIds")] UserCreateViewModel userForm)
        {
            userForm.AvailableRoles = _readableUser.GetUserRolesForSelectList();

            if (ModelState.IsValid)
            {
                // Create a new user entity
                var newUser = new User
                {
                    FirstName = userForm.FirstName,
                    LastName = userForm.LastName,
                    Email = userForm.Email,
                    Login = userForm.Login,
                    PhoneNumber = userForm.PhoneNumber,
                    Password = _passwordHasher.HashPassword(userForm, userForm.Password),
                    Roles = []
                };

                _context.Add(newUser);
                await _context.SaveChangesAsync();

                // Add selected roles to the user
                foreach (var roleId in userForm.SelectedRoleIds)
                {
                    var role = await _context.UserRoles.FindAsync(roleId);
                    if (role != null)
                    {
                        newUser.Roles.Add(role);
                    }
                }

                // Add the user to the database and save changes
                _context.Users.Update(newUser);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(userForm);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _context.Users
                .Where(u => u.Id == id)
                .Select(u => new UserEditViewModel {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    Roles = u.Roles
                }).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            user.AvailableRoles = _readableUser.GetUserRolesForSelectList();

            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,Password,ConfirmPassword,SelectedRoleIds,CreatedDate")] UserEditViewModel userForm)
        {
            if (id != userForm.Id)
            {
                return NotFound();
            }

            userForm.AvailableRoles = _readableUser.GetUserRolesForSelectList();

            if (ModelState.IsValid)
            {
                try
                {
                    var updatedUser = await _context.Users
                        .Include(u => u.Roles)
                        .FirstOrDefaultAsync(u => u.Id == id);

                    if (updatedUser != null)
                    {
                        updatedUser.FirstName = userForm.FirstName;
                        updatedUser.LastName = userForm.LastName;
                        updatedUser.Email = userForm.Email;
                        updatedUser.PhoneNumber = userForm.PhoneNumber;

                        var currentRoleIds = updatedUser.Roles.Select(r => r.Id).ToList();
                        var newRoleIds = userForm.SelectedRoleIds;
                        var rolesToAdd = newRoleIds.Except(currentRoleIds).ToList();
                        var rolesToRemove = currentRoleIds.Except(newRoleIds).ToList();

                        // Remove roles that are no longer selected
                        foreach (var roleIdToRemove in rolesToRemove)
                        {
                            var role = updatedUser.Roles.FirstOrDefault(r => r.Id == roleIdToRemove);
                            if (role != null)
                            {
                                updatedUser.Roles.Remove(role);
                            }
                        }

                        // Add new roles that are selected but not yet assigned
                        foreach (var roleIdToAdd in rolesToAdd)
                        {
                            var role = await _context.UserRoles.FindAsync(roleIdToAdd);
                            if (role != null)
                            {
                                updatedUser.Roles.Add(role);
                            }
                        }

                        // Update password if necesssary
                        if (userForm.Password != null && userForm.Password.Length > 0 && userForm.Password == userForm.ConfirmPassword)
                        {
                            updatedUser.Password = _passwordHasher.HashPassword(updatedUser, userForm.Password);
                        }

                        _context.Update(updatedUser);
                        await _context.SaveChangesAsync();

                        return RedirectToAction(nameof(Index));
                    }

                    ViewBag.Message = new { Type = "error", Message = $"User Id: [{id}] not found." };
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(userForm.Id))
                    {
                        ViewBag.Message = new { Type = "error", Message = $"User Id: [{id}] not found." };
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            else
            {
                ViewBag.Message = new { Type = "error", Text = $"Model is not valid." };
            }

            return View(userForm);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
               .Where(u => u.Id == id)
               .Include(u => u.Roles)
               .Select(u => new UserIndexViewModel
               {
                   Id = u.Id,
                   FirstName = u.FirstName,
                   LastName = u.LastName,
                   Email = u.Email,
                   Login = u.Login,
                   PhoneNumber = u.PhoneNumber,
                   Roles = string.Join(", ", u.Roles.Select(r => r.Name))
               })
               .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            
            if (user == null)
            {
                return null; // User not found
            }

            // Verify the password
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
            if (result == PasswordVerificationResult.Success)
            {
                return user; // Successful login
            }

            return null; // Invalid password
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}

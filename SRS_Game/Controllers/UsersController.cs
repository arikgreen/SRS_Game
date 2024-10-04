using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SRS_Game.Data;
using SRS_Game.Interfaces;
using SRS_Game.Models;

namespace SRS_Game.Controllers
{
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
                .Join(_context.UserRoles,
                u => u.UserRoleFK,
                r => r.Id,
                (u, r) => new UserIndexViewModel
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Login = u.Login,
                    PhoneNumber = u.PhoneNumber,
                    Role = r.Name
                }).ToListAsync();

            return View(users);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int id)
        {
            //var user = _readableUser.GetUserDetailsByIdAsync(id);

            var user = await _context.Users
                .Where(u => u.Id == id)
                .Join(_context.UserRoles, u => u.UserRoleFK, r => r.Id,
                (u, r) => new UserIndexViewModel
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Login = u.Login,
                    PhoneNumber = u.PhoneNumber,
                    Role = r.Name
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
            ViewBag.Roles = _readableUser.GetUserRolesForSelectList();

            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Login,Email,PhoneNumber,Password,ConfirmPassword,UserRoleFK")] UserCreateViewModel userForm)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FirstName = userForm.FirstName,
                    LastName = userForm.LastName,
                    Email = userForm.Email,
                    Login = userForm.Login,
                    PhoneNumber = userForm.PhoneNumber,
                    Password = _passwordHasher.HashPassword(userForm, userForm.Password),
                    UserRoleFK = userForm.UserRoleFK
                };

                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Roles = _readableUser.GetUserRolesForSelectList();

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
                    UserRoleFK = u.UserRoleFK
                }).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            ViewBag.Roles = _readableUser.GetUserRolesForSelectList();

            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,Password,ConfirmPassword,UserRoleFK,CreatedDate")] UserEditViewModel user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var currentUser = await _context.Users.FindAsync(id);

                    if (currentUser != null)
                    {
                        currentUser.FirstName = user.FirstName;
                        currentUser.LastName = user.LastName;
                        currentUser.Email = user.Email;
                        currentUser.PhoneNumber = user.PhoneNumber;
                        currentUser.UserRoleFK = user.UserRoleFK;

                        if (user.Password != null && user.Password.Length > 0 && user.Password == user.ConfirmPassword)
                        {
                            currentUser.Password = _passwordHasher.HashPassword(currentUser, user.Password);
                        }

                        _context.Update(currentUser);
                        await _context.SaveChangesAsync();
                    }

                    ViewBag.Message = new { Type = "error", Message = $"User Id: [{id}] not found." };
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        ViewBag.Message = new { Type = "error", Message = $"User Id: [{id}] not found." };
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = new { Type = "error", Text = $"Model is not valid." };

            ViewBag.Roles = _readableUser.GetUserRolesForSelectList();

            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
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

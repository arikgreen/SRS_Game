using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SRS_Game.Data;
using SRS_Game.Interfaces;
using System.Data.Entity;

namespace SRS_Game.Services
{
    public class UserService : IReadableUser
    {
        private readonly SRS_GameDbContext _context;

        public UserService(SRS_GameDbContext context)
        {
            _context = context;
        }

        //public IEnumerable<UserIndexViewModel> GetAllUsers()
        //{
        //    var users = _context.Users
        //        .Join(_context.UserRoles,
        //        u => u.UserRoleFK,
        //        r => r.Id,
        //        (u, r) => new UserIndexViewModel
        //        {
        //            Id = u.Id,
        //            FirstName = u.FirstName,
        //            LastName = u.LastName,
        //            Email = u.Email,
        //            Login = u.Login,
        //            PhoneNumber = u.PhoneNumber,
        //            Role = r.Name
        //        })
        //        .ToList();

        //    return users;
        //}

        //public async Task<User?> GetUserByIdAsync(int? id)
        //{
        //    return await _context.Users.FindAsync(id);
        //}

        //public UserIndexViewModel? GetUserDetailsByIdAsync(int id)
        //{
        //    var user = _context.Users
        //        .Where(u => u.Id == id)
        //        .Join(_context.UserRoles, u => u.UserRoleFK, r => r.Id, 
        //        (u, r) => new UserIndexViewModel
        //        {
        //            Id = u.Id,
        //            FirstName = u.FirstName,
        //            LastName = u.LastName,
        //            Email = u.Email,
        //            Login = u.Login,
        //            PhoneNumber = u.PhoneNumber,
        //            Role = r.Name
        //        })
        //        .FirstOrDefault();

        //    return user;
        //}

        //public async Task AddAsync(User User)
        //{
        //    _context.Users.Add(User);
        //    await _context.SaveChangesAsync();
        //}
        
        //public async Task UpdateAsync(User user)
        //{
        //    var password = await _context.Users
        //        .Where(u => u.Id == user.Id)
        //        .Select(u => u.Password)
        //        .FirstOrDefaultAsync();

        //    if (password != null)
        //    {
        //        user.Password = password;
        //        _context.Users.Update(user);
        //        await _context.SaveChangesAsync();
        //    }
        //}

        //public async Task UpdatePasswordAsync(User user)
        //{
        //    await _context.Users
        //    .Where(u => u.Id == user.Id)
        //    .ExecuteUpdateAsync(b =>
        //        b.SetProperty(u => u.Password, user.Password)
        //    );
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        throw new KeyNotFoundException($"User with id {id} not found.");
        //    }

        //    _context.Users.Remove(user);
        //    await _context.SaveChangesAsync();

        //    /* Code to delete User */
        //    //throw new NotImplementedException();
        //}

        public List<SelectListItem> GetUserRolesForSelectList()
        {
            var roles = _context.UserRoles
                .Select(r => new SelectListItem
                {
                    Value = r.Id.ToString(),
                    Text = r.Name
                 })
                .ToList();

            //return new SelectList(roles, "Value", "Text");
            return roles;
        }
    }
}

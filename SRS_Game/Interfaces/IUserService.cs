using Microsoft.AspNetCore.Mvc.Rendering;
using SRS_Game.Models;

namespace SRS_Game.Interfaces
{
    public interface IReadableUser
    {
        //IEnumerable<UserIndexViewModel> GetAllUsers();
        //Task<User?> GetUserByIdAsync(int? id);
        //UserIndexViewModel GetUserDetailsByIdAsync(int id);
        //Task <SelectList> GetUserRolesForSelectListAsync();   // don't know why not working
        SelectList GetUserRolesForSelectList();
    }

    public interface IWritableUser
    {
        Task AddAsync(User User);
        Task UpdateAsync(User User);
        Task UpdatePasswordAsync(User User);
        Task DeleteAsync(int id);
    }
}

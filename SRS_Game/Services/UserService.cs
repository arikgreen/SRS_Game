using SRS_Game.Data;
using SRS_Game.Models;

namespace SRS_Game.Services
{
    public interface IReadableUser
    {
        IEnumerable<User?> GetAll();
        Task<User> GetAsync(int? id);
        
    }
    public interface IWritableUser
    {
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }

    public class UserService(SRS_GameDbContext context) : IReadableUser, IWritableUser
    {
        private readonly SRS_GameDbContext _context = context;

        public IEnumerable<User?> GetAll()
        {
            var users = _context.Users;

            return users;
        }
        
        public Task<User> GetAsync(int? id)
        {
            /* Code to read specyfication */
            throw new NotImplementedException();
        }

        public Task AddAsync(User user)
        {
            /* Code to add user */
            throw new NotImplementedException();
        }
        public Task UpdateAsync(User user)
        {
            /* Code to update user */
            throw new NotImplementedException();
        }
        public Task DeleteAsync(int id)
        {
            /* Code to delete user */
            throw new NotImplementedException();
        }
    }
}

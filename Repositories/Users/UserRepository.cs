using Microsoft.EntityFrameworkCore;
using WebSupport.Models.DB;
using WebSupport.Models.Entities;

namespace WebSupport.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<User>> GetAll()
        {
            if (_context == null)
            {
                return await _context.Users.ToListAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task<User> GetUser(string username, string password)
        {
            if (_context != null)
            {
                var users = await GetAll();
                var user = users.Where(u => u.Login == username && u.HashedPassword == password).Single();

                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> isAdmin(int userId)
        {
            if (_context != null)
            {
                var user  = await _context.Users.Where(u => u.Id==userId).SingleAsync();
                return user.Admin;
            }
            else
            {
                return false;
            }
        }
    }
}

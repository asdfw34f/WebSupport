using Microsoft.EntityFrameworkCore;
using WebSupport.Data;
using WebSupport.DataEntities;

namespace WebSupport.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        RedmineContext _context;

        public UserRepository(RedmineContext context)
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
                var user = await _context.Users.Where(u => u.Id == userId).SingleAsync();
                return user.Admin;
            }
            else
            {
                return false;
            }
        }
    }
}


//MySql.Data.EntityFrameworkCore
//"Server=localhost; Database=redmine;User Id=root;Password=x897ty; Port=3307;"
using WebSupport.Models.Entities;

namespace WebSupport.Repositories.Users
{
    public interface IUserRepository
    {
        Task<IList<User>> GetAll();
        Task<User> GetUser(string username, string password);
        Task<bool> isAdmin(int userId);
    }
}

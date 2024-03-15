using Microsoft.AspNetCore.Mvc;
using WebSupport.Models.DB;

namespace WebSupport.Account
{
    public interface IAuthentication
    {
        public Task<bool> Log_In(string username, string password, HttpContext context);
    }
}

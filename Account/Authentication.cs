using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using WebSupport.Repositories.Users;
using WebSupport.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebSupport.Account
{
    public class Authentication : IAuthentication
    {
        IUserRepository repository;
        RedmineContext redmineContext;
        public Authentication(IUserRepository repository, RedmineContext redmineContext)
        {
            this.repository = repository;
            this.redmineContext = redmineContext;
        }

        async Task<bool> IAuthentication.Log_In(string username, string password, HttpContext context)
        {

            var temp = await redmineContext.Users.SingleAsync(u => u.Login == username);

            if (temp == null)
            {
                return false;
            }

            var hashed = CalculateHash(temp.Salt, password);
            
            var user = await redmineContext.Users.Where(u=>u.Login == username && u.HashedPassword == hashed).FirstAsync();
            
            if (user != null)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                context.Response.Cookies.Append("username", username);
                context.Response.Cookies.Append("password", password);
                Account.currentUser = user;
                Account.isAuthorized = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string CalculateHash(string user_salt, string plain_password)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                byte[] saltBytes = Encoding.UTF8.GetBytes(user_salt);


                byte[] passwordBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(plain_password));

                var ss = user_salt + BitConverter.ToString(passwordBytes).Replace("-", "").ToLower();

                byte[] hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(ss));
                string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return hash;
            }
        }

        /*
         * 
         <?php
$plain_password = 'Aa001!5@';

  $user_salt = 'f3a311e14dd209287d43990c585330ba';
  
  $hash = sha1( $user_salt . sha1($plain_password));

  echo $hash . "\n";
?>

         */
    }
}

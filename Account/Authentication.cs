using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using WebSupport.Models.DB;
using WebSupport.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using WebSupport.Repositories.Users;

namespace WebSupport.Account
{
    public class Authentication : IAuthentication
    {
        IUserRepository repository;

        public Authentication(IUserRepository repository)
        {
            this.repository = repository;
        }

        async Task<bool> IAuthentication.Log_In(string username, string password, HttpContext context, ApplicationContext appContext)
        {
            var user = await repository.GetUser(username, GetHash(password));
            if (user.Login != "")
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                context.Response.Cookies.Append("username", username);
                context.Response.Cookies.Append("password", password);
                Account.currentUser = user;
                return true;
            }
            else
            {
                return false;
            }
        }

        private string GetHash(string text)
        {
            using (var sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(text));

                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2").ToLower());
                }
                return sb.ToString();
            }
        }

    }
}

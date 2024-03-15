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
        ApplicationContext applicationContext;
        public Authentication(IUserRepository repository, ApplicationContext applicationContext)
        {
            this.repository = repository;
            this.applicationContext = applicationContext;
        }

        async Task<bool> IAuthentication.Log_In(string username, string password, HttpContext context)
        {
            var hashed = GetHash(password);
            var user = await repository.GetUser(username, hashed);
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

                byte[] hashedBytes = sha1.ComputeHash(hash);
                string hashedString = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hashedString;
            }
        }
    }
}

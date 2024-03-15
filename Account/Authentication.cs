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

namespace WebSupport.Account
{
    public class Authentication : IAuthentication
    {
        async Task<bool> IAuthentication.Log_In(string username, string password, HttpContext context, ApplicationContext appContext)
        {
            if (ExitUser(username, password, appContext))
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                context.Response.Cookies.Append("username", username);
                context.Response.Cookies.Append("password", password);
                
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ExitUser(string username, string password, ApplicationContext application)
        {
            var hash = GetHash(password);

            var res = application.Users.Where(u => u.login == username && u.hashed_password == hash).Single();

            if (res.login != "")
            {
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

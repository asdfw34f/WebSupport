using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RedmineLibrary.Authentication;
using System.Security.Claims;

namespace WebSupport.Account
{
    public class Authentication : IAuthentication
    {
        async Task<bool> IAuthentication.Log_In(string username, string password, HttpContext context)
        {
            if (Login.Login_UsernamePassword(username, password))
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

    }
}

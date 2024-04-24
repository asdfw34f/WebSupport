using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using Renci.SshNet;
using System.Net;
using WebSupport.Account;
using WebSupport.Data;
using WebSupport.Repositories.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var con = builder.Configuration.GetConnectionString("DefaultConnection");







builder.Services.AddDbContext<RedmineContext>(
    options => options.UseMySQL(
        con
        ));

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddTransient<IAuthentication, Authentication>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => options.LoginPath = "/Web-Support/login");
builder.Services.AddAuthorization();

var bhost = new HostBuilder();

var app = builder.Build();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// обработка ошибок HTTP
app.UseStatusCodePages(async statusCodeContext =>
{
    var response = statusCodeContext.HttpContext.Response;
    var path = statusCodeContext.HttpContext.Request.Path;

    response.ContentType = "text/plain; charset=UTF-8";
    int code = response.StatusCode;

    switch (code)
    {
        case 401:
            await response.WriteAsync($"Path: {path}. Access Denied ERROR");
            break;
        case 404:
            await response.WriteAsync($"Path: {path}. Not Found ERROR");
            break;
        case 500:
            await response.WriteAsync($"Path: {path}. Internal server ERROR");
            break;
        default:
            await response.WriteAsync($"Path: {path}. Generic ERROR");
            break;
    }

    if (response.StatusCode == 403)
    {
        await response.WriteAsync($"Path: {path}. Access Denied ");
    }
    else if (response.StatusCode == 404)
    {
        await response.WriteAsync($"Resource {path} Not Found");
    } 
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Web-Support/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.MapControllerRoute(
    name: "default",
    pattern: "/Web-Support/login",
    defaults: new { controller = "Authentication", action = "Index" });

app.MapGet("/Web-Support/logout", async (HttpContext context) =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    context.Response.Cookies.Delete("username");
    context.Response.Cookies.Delete("password");

    return Results.Redirect("/Web-Support/login");
});
app.Run();
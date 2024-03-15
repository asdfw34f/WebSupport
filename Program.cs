using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using WebSupport.Account;
using WebSupport.Models.DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var con = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(
    options => options.UseMySql(
        con, 
        ServerVersion.AutoDetect(con)
        ));

builder.Services.AddTransient<IAuthentication, Authentication>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => options.LoginPath = "/login");
builder.Services.AddAuthorization();

var bhost = new HostBuilder();


var app = builder.Build();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


// ��������� ������ HTTP
app.UseStatusCodePages(async statusCodeContext =>
{
    var response = statusCodeContext.HttpContext.Response;
    var path = statusCodeContext.HttpContext.Request.Path;

    response.ContentType = "text/plain; charset=UTF-8";
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
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Authentication}/{action=Index}/{id?}",
    defaults: new { controller = "Authentication", action = "Index" });

app.MapGet("/logout", async (HttpContext context) =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Results.Redirect("/login");
});
app.Run();


/*
 MySqlConnector.MySqlException
  HResult=0x80004005
  ��������� = Unable to connect to any of the specified MySQL hosts.
  �������� = MySqlConnector
  ����������� �����:
   � MySqlConnector.Core.ServerSession.<OpenTcpSocketAsync>d__111.MoveNext()
   � MySqlConnector.Core.ServerSession.<ConnectAsync>d__98.MoveNext()
   � MySqlConnector.MySqlConnection.<CreateSessionAsync>d__133.MoveNext()
   � MySqlConnector.MySqlConnection.<CreateSessionAsync>d__133.MoveNext()
   � System.Threading.Tasks.ValueTask`1.get_Result()
   � MySqlConnector.MySqlConnection.<OpenAsync>d__29.MoveNext()
   � MySqlConnector.MySqlConnection.Open()
   � Microsoft.EntityFrameworkCore.ServerVersion.AutoDetect(String connectionString)
   � Program.<>c__DisplayClass0_0.<<Main>$>b__0(DbContextOptionsBuilder options) � C:\Users\������\source\repos\WebSupport\WebSupport\Program.cs:������ 17
   � Microsoft.Extensions.DependencyInjection.EntityFrameworkServiceCollectionExtensions.<>c__DisplayClass1_0`2.<AddDbContext>b__0(IServiceProvider _, DbContextOptionsBuilder b)
   � Microsoft.Extensions.DependencyInjection.EntityFrameworkServiceCollectionExtensions.CreateDbContextOptions[TContext](IServiceProvider applicationServiceProvider, Action`2 optionsAction)
   � Microsoft.Extensions.DependencyInjection.EntityFrameworkServiceCollectionExtensions.<>c__DisplayClass17_0`1.<AddCoreServices>b__0(IServiceProvider p)
   � Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSiteMain(ServiceCallSite callSite, TArgument argument)
   � Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitCache(ServiceCallSite callSite, RuntimeResolverContext context, ServiceProviderEngineScope serviceProviderEngine, RuntimeResolverLock lockType)
   � Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScopeCache(ServiceCallSite callSite, RuntimeResolverContext context)
   � Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument)
   � Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitConstructor(ConstructorCallSite constructorCallSite, RuntimeResolverContext context)
   � Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSiteMain(ServiceCallSite callSite, TArgument argument)
   � Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitCache(ServiceCallSite callSite, RuntimeResolverContext context, ServiceProviderEngineScope serviceProviderEngine, RuntimeResolverLock lockType)
   � Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScopeCache(ServiceCallSite callSite, RuntimeResolverContext context)
   � Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument)
   � Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.Resolve(ServiceCallSite callSite, ServiceProviderEngineScope scope)
   � Microsoft.Extensions.DependencyInjection.ServiceLookup.DynamicServiceProviderEngine.<>c__DisplayClass2_0.<RealizeService>b__0(ServiceProviderEngineScope scope)
   � Microsoft.Extensions.DependencyInjection.ServiceProvider.GetService(ServiceIdentifier serviceIdentifier, ServiceProviderEngineScope serviceProviderEngineScope)
   � Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngineScope.GetService(Type serviceType)
   � Microsoft.AspNetCore.Mvc.Controllers.ControllerFactoryProvider.<>c__DisplayClass6_0.<CreateControllerFactory>g__CreateController|0(ControllerContext controllerContext)
   � Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
   � Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeInnerFilterAsync()
*/
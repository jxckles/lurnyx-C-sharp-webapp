using Lurnyx.WebApp;
using Lurnyx.WebApp.Extensions.Configuration;

var appBuilder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    ContentRootPath = Directory.GetCurrentDirectory(),
});

appBuilder.Configuration.AddJsonFile("appsettings.json",
    optional: true,
    reloadOnChange: true);

appBuilder.WebHost.UseIISIntegration();

appBuilder.Logging
    .AddConfiguration(appBuilder.Configuration.GetLoggingSection())
    .AddConsole()
    .AddDebug();

var configurer = new StartupConfigurer(appBuilder.Configuration);
configurer.ConfigureServices(appBuilder.Services);

var app = appBuilder.Build();
// 404 error handling
app.UseStatusCodePagesWithReExecute("/html/404.html");

app.UseAuthentication();
app.UseAuthorization();

configurer.ConfigureApp(app, app.Environment);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}");

app.MapControllerRoute(
    name: "user-views",
    pattern: "Dashboard/{action}",
    defaults: new { controller = "Dashboard" });

app.MapControllers();
app.MapRazorPages();

// Run application
app.Run();

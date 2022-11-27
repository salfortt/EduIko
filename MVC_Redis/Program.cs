using Microsoft.AspNetCore.Hosting.Server;
using MVC_Redis;
using MVC_Redis.Controllers;
using StackExchange.Redis;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddRazorRuntimeCompilation();
IConfiguration configuration = builder.Configuration;
var options = ConfigurationOptions.Parse(configuration.GetConnectionString("Redis")); // host1:port1, host2:port2, ...
options.Password = "istanbul343,,";
 
var multiplexer = ConnectionMultiplexer.Connect(options);
 
builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);
builder.Services.AddSingleton<ICacheService, RedisCacheService>();
builder.Services.AddSingleton<ICategoryService, CategoryService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

//app.AddAuthentication().AddFacebook().AddTwitter();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();

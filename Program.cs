using Microsoft.EntityFrameworkCore;
using BrewBlissInfo.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BrewBlissInfoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BrewBlissInfoDbContext")));

builder.Services.AddControllersWithViews();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
    
var app = builder.Build();

app.UseCors("AllowAll");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
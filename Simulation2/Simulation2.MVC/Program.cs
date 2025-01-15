using Microsoft.EntityFrameworkCore;
using Simulation2.BL;
using Simulation2.BL.Profiles;
using Simulation2.DAL.Contexts;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddBLService();
builder.Services.AddAutoMapper(typeof(TechnicianProfile));



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContexts>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql")));



var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

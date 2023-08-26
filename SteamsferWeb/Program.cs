//Creating a builder
using Microsoft.EntityFrameworkCore;
using Steamsfer.DataAccess.Data;
using Steamsfer.DataAccess.Repository;
using Steamsfer.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Steamsfer.Utilities;
using Steamsfer.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container, old Startup File.
// Dependency injection will be added into services.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<CommonMethods>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
//builder.Services.AddAuthentication().AddSteam();
builder.Services.AddAuthentication()
    .AddSteam(options =>
    {
        options.ApplicationKey = builder.Configuration["Steam:APIKey"];
    });


//Adding DbContext service to container with options and ConnectionString
builder.Services.AddDbContext<ApplicationDBContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false);
builder.Services.AddIdentity<IdentityUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ApplicationDBContext>();
builder.Services.AddRazorPages();
var app = builder.Build();



// HTTP REQUEST PIPELINE
// Configure the HTTP request pipeline.
// IsProduction() can be used later
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days.
    // You may want to change this for production scenarios,
    // see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

//Allow to use wwwroot static files
app.UseStaticFiles();

app.UseRouting();

//Authentication always comes before Authorization
app.UseAuthentication(); //Checks if username and password valid
app.UseAuthorization(); //Manages access according to UserRoles
app.MapRazorPages();
// Defining the default route should be followed
app.MapControllerRoute(
    name: "areas",
    pattern: "{area=User}/{controller=Home}/{action=Index}/{id?}");

app.Run();

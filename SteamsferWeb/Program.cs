//Creating a builder
using Microsoft.EntityFrameworkCore;
using Steamsfer.DataAccess.Data;
using Steamsfer.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container, old Startup File.
// Dependency injection will be added into services.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<CommonMethods>();

//Adding DbContext service to container with options and ConnectionString
builder.Services.AddDbContext<ApplicationDBContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

app.UseAuthorization();

// Defining the default route should be followed
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

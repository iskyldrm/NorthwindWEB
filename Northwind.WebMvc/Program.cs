using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Northwind.DAL.Abstract;
using Northwind.DAL.Concrete;
using Northwind.WebMvc.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IShippersDal, ShipperDal>();
builder.Services.AddScoped<ICustomerDal, CustomerDal>();

//IdentityServerAyARLARI
#region IdenetityServerAyarlarý
string constr = @"server=(localdb)\mssqllocaldb;database=NorthwindIdentity;Trusted_Connection=True";
builder.Services.AddDbContext<MyIdentityDbContext>(options => options.UseSqlServer(constr));


builder.Services.AddIdentity<MyUser, IdentityRole>()
    .AddEntityFrameworkStores<MyIdentityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";


});
#endregion



//Cookiebase authentication
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(x =>
//    {
//        x.LoginPath = "/User/Giris";
//        x.LogoutPath = "/User/Cikis";
//        x.AccessDeniedPath = "/User/Yasak";
//    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

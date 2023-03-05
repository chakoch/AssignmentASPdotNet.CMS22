using AssignmentASPdotNet.CMS22.Contexts;
using AssignmentASPdotNet.CMS22.Models.Identity;
using AssignmentASPdotNet.CMS22.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("UserSql")));
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ProductsSql")));
builder.Services.AddScoped<ProfileHandler>();
builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders(); //Token
builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/Account/Login";
    x.AccessDeniedPath = "/Errors/AccessDenied";
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddScoped<ProductReviewService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ShowcaseService>();




var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

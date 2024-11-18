using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CMA.Areas.Identity.Data;
using CMA.Context;
namespace CMA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("CMAContextConnection") ?? throw new InvalidOperationException("Connection string 'CMAContextConnection' not found.");

            builder.Services.AddDbContext<CMAContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<CMAUsers>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<CMAContext>();
            builder.Services.AddRazorPages();
            //Configure authentication (password)
            builder.Services.Configure<IdentityOptions>(options =>
            {
                //Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                //User settings
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedEmail = false;
            });
            // Add session
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(60);
                options.IOTimeout = TimeSpan.FromSeconds(60);
                options.Cookie.Name = ".AspNetCore.Session";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.Path = "/";
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
           
            app.UseAuthorization();
            app.UseSession();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
            app.Run();
        }
    }
}

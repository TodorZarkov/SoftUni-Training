using GameZone.Data;
using GameZone.Services;
using GameZone.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GameZone
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<GameZoneDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {
				options.SignIn.RequireConfirmedAccount = builder.Configuration
						.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");

				options.Password.RequireDigit = builder.Configuration
					.GetValue<bool>("Identity:Password:RequireDigit");

				options.Password.RequireNonAlphanumeric = builder.Configuration
					.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");

				options.Password.RequireUppercase = builder.Configuration
					.GetValue<bool>("Identity:Password:RequireUppercase");

			})
                .AddEntityFrameworkStores<GameZoneDbContext>();
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IGameService, GameService>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddScoped<IGamerGameService, GamerGameService>();

            var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
namespace EFAspCore
{
    using EFAspCore.Core.Contracts;
    using EFAspCore.Core.Services;
    using EFAspCore.Infrastructure.Model;
    using Microsoft.EntityFrameworkCore;


    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<WebShopDbContext>(options =>
                options
                .UseSqlServer(builder.Configuration.GetConnectionString("MSSQLConnection")));
            //builder.Services.AddDbContext<WebShopDbContext>(optionns =>
            //    optionns
            //    .UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection"))
            //    .UseSnakeCaseNamingConvention());

            builder.Services.AddScoped<IProductService, ProductService>();

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Common.Services;
using SoftUniBazar.Common.Services.Interfaces;
using SoftUniBazar.Data;
using SoftUniBazar.ModelBinder;
using SoftUniBazar.Services;
using SoftUniBazar.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString =
                builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");



builder.Services.AddDbContext<BazarDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();




builder.Services
                .AddDefaultIdentity<IdentityUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount
                        = builder.Configuration.GetValue<bool>("SignIn:RequireConfirmedAccount");

                    options.Password.RequireNonAlphanumeric
                        = builder.Configuration.GetValue<bool>("Password:RequireNonAlphanumeric");

                    options.Password.RequireUppercase
                        = builder.Configuration.GetValue<bool>("Password:RequireUppercase");


                    options.Password.RequireDigit
                        = builder.Configuration.GetValue<bool>("Password:RequireDigit");
                })
                .AddEntityFrameworkStores<BazarDbContext>();



builder.Services.AddControllersWithViews(opt =>
{
    opt.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
});


builder.Services.AddScoped<IAdService, AdService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IDateTimeProvider, DateTimeNowProvider>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
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

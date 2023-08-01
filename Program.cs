using CRUDSystem.Data;
using CRUDSystem.Repository.AccountRepository;
using CRUDSystem.Repository.CenterRepository;
using CRUDSystem.Repository.ClientRepository;
using CRUDSystem.Repository.GovernorateRepository;
using CRUDSystem.Repository.VillageRepository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace CRUDSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IGovernorateRepository, GovernorateRepository>();
            builder.Services.AddScoped<ICenterRepository, CenterRepository>();
            builder.Services.AddScoped<IVillageRepository, VillageRepository>();
            builder.Services.AddScoped<IAccountRepository, AccountRepositiry>();

            builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(
                        builder.Configuration.GetConnectionString("ConStr")));
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Client}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
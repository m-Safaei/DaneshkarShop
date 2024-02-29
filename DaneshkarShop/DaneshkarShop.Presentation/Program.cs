using DaneshkarShop.Data.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;

namespace DaneshkarShop.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Builder 

            
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            #region Context
            
            builder.Services.AddDbContext<DaneshkarDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DaneshkarShopConnectionString"));
            });

            #endregion
            
            var app = builder.Build();


            #endregion

            #region App Services


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
                name: "area",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

            #endregion

        }
    }
}

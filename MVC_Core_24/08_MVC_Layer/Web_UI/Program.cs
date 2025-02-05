using CORE;
using Microsoft.EntityFrameworkCore;
using Services;

namespace Web_UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //add dependency  of dbcontext with cs

            builder.Services.AddDbContext<CoreDbContext>(

                Options =>
                {
                    Options.UseSqlServer(builder.Configuration.GetConnectionString("EFCodeFirstApprochLayer"));
                }
                );


            // All layer add depenencies
            
            DependencyRegisters.RegisterAllDependencies(builder.Services);


  



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

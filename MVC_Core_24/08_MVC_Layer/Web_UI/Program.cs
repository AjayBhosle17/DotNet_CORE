using CORE;
using Microsoft.AspNetCore.Mvc.Authorization;
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

            //Add Globally Authrization

            builder.Services.AddControllersWithViews(configure =>
            {
                configure.Filters.Add(new AuthorizeFilter());
            });

            //add dependency  of dbcontext with cs

            builder.Services.AddDbContext<CoreDbContext>(

                Options =>
                {
                    Options.UseSqlServer(builder.Configuration.GetConnectionString("EFCodeFirstApprochLayer"));
                }
                );


            // All layer add depenencies
            
            DependencyRegisters.RegisterAllDependencies(builder.Services);


            //Authenticate Dependency in program.cs

            builder.Services.AddAuthentication("MyAppAuthenticationScheme").AddCookie
                ("MyAppAuthenticationScheme", options =>
                {
                    options.LoginPath = "/Account/Login/";
                    options.AccessDeniedPath = "/Account/AccessDenied";


                });


            //Add Authorization Dependency


            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy =>
                    policy.RequireRole("admin"));

                options.AddPolicy("UserOnly", policy =>
                    policy.RequireRole("user"));

                // Add here also

            });


            //Registering Dependency

            //1.Transient

            // builder.Services.AddTransient<TestService>();
            builder.Services.AddScoped<TestService>();

           // builder.Services.AddSingleton<TestService>();





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

namespace _01_MVC_Core_Introduction
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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

           /* app.MapControllerRoute( // use here conventional based routing
                name: "defaultname",
                pattern: "{controller=Category}/{action=Index}/{name}");*/

            app.MapControllerRoute(
               name: "default",
               pattern: "{controller=Category}/{action=Index}/{id?}");


            app.Run();
        }
    }
}

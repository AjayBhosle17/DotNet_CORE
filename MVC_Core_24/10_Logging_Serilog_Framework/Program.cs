using Serilog.Sinks.MSSqlServer;
using Serilog;

namespace _10_Logging_Serilog_Framework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);





            // Define column options for log table (optional)
            var columnOptions = new ColumnOptions();

            // Configure Serilog with MSSQL logging
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()  // Logs to console
                .WriteTo.MSSqlServer(
                    connectionString: "LogCS",
                    sinkOptions: new MSSqlServerSinkOptions
                    {
                        TableName = "Logs",  // Name of the table in DB
                        AutoCreateSqlTable = true  // Automatically creates the table
                    },
                    columnOptions: columnOptions
                )
                .CreateLogger();

            // Use Serilog as the logger for the application
            builder.Host.UseSerilog();



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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Log}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

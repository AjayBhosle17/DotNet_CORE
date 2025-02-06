using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Services.MappingProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DependencyRegister
    {
        public static void RegisterDependencies(IServiceCollection services)
        {

            services.AddScoped<IBlogPostRepository, BlogPostRepository>();           
            services.AddScoped<IBlogPostService,BlogPostService>();


            services.AddAutoMapper(typeof(MyAppProfile));
            
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DependencyRegisters
    {
        public static void RegisterAllDependencies(IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();


            // Add here also  new dependencies

        }
    }
}

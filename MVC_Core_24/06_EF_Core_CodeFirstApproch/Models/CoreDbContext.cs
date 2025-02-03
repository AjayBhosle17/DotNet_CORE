using _06_EF_Core_CodeFirstApproch.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _06_EF_Core_CodeFirstApproch.Models
{
    public class CoreDbContext: DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options):base(options) 
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Product { get; set; }



    }
}

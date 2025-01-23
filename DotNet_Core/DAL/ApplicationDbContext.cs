using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Category> categories {  get; set; }

        public DbSet<Product> products { get; set; }    
    }
}

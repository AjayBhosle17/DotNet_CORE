
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options):base(options) { }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Category>().HasData(
            

                new Category() { Id = 1, Name = "Home Appliences", Order = 5 },
                new Category() { Id = 2, Name = "Groceries", Order = 7 }
            );
           
            modelBuilder.Entity<Product>().HasData(


                new Product() { Id = 1, Name = "TV", Price=20000 , Stock =40 , CategoryId=1},
                new Product() { Id = 2, Name = "NoteBooks",Price=400 ,Stock=14 ,CategoryId=2}
            );
        }
    }
}

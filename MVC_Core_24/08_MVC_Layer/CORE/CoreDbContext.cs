
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

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Category>().HasData(


                new Category() { Id = 1, Name = "Home Appliences", Order = 5 },
                new Category() { Id = 2, Name = "Groceries", Order = 7 }
            );

            modelBuilder.Entity<Product>().HasData(


                new Product() { Id = 1, Name = "TV", Price = 20000, Stock = 40, CategoryId = 1 },
                new Product() { Id = 2, Name = "NoteBooks", Price = 400, Stock = 14, CategoryId = 2 }
            );
          
            modelBuilder.Entity<Role>().HasData(

                new Role() { Id = 1, RoleName = "admin" },
                new Role() { Id = 2, RoleName = "user" }
            );


            modelBuilder.Entity<User>().HasData
                (new User()
                {
                    Id = 1,
                    FirstName = "admin",
                    LastName = "admin",
                    Email = "admin@gmail.com",
                    Age = 22,
                    DateOfBirth = DateTime.Parse("27/06/2002"),
                    Password = "123456",
                    FacebookUrl = "https://www.facebook.com/123"
                }, 

                new User()
                {
                    Id = 2,
                    FirstName = "user",
                    LastName = "user",
                    Email = "user@gmail.com",
                    Age = 25,
                    DateOfBirth = DateTime.Parse("10/07/2006"),
                    Password = "123456",
                    FacebookUrl = "https://www.facebook.com/456"
                }
                );

        
            modelBuilder.Entity<UserRole>().HasData
                (
                    new UserRole() { Id = 1, UserId = 1, RoleId = 1 },
                    new UserRole() { Id = 2, UserId = 2, RoleId = 2 }
                );


            base.OnModelCreating(modelBuilder);

        }
    }
}

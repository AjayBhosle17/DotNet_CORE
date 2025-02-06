using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE
{
    public class PostDBContext : DbContext
    {
        public PostDBContext(DbContextOptions<PostDBContext> options):base(options) { }
      
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /* modelBuilder.Entity<Post>().HasData(

                new Post() {
                   
                    PostId = 1,
                    Title = "V#",
                    Content = "Foundation",
                    PublishedDate = new DateTime(01,01,2025)

                }

            );*/
            modelBuilder.Entity<Post>()
            .Property(p => p.PublishedDate)
            .HasDefaultValueSql("GETDATE()");

            base.OnModelCreating(modelBuilder);
        }
    }
}

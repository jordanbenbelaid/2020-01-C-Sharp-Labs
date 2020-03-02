using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_60_cats_API.Models
{
    public class CatDbContext : DbContext
    {
        public CatDbContext(DbContextOptions<CatDbContext> options) : base(options) { }
        //DbSet = SQL Table Names
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Category> Categories { get; set; }

        string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = CatDatabase;";

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                
                new Category { CategoryID=1, CategoryName="Bengal"},
                new Category { CategoryID=2, CategoryName="Tabby"},
                new Category { CategoryID=3, CategoryName="Siamese"}
                
                );

            builder.Entity<Cat>().HasData(
                
                new Cat { CatID=1, CatName = "Kitty", CategoryID=1},
                new Cat { CatID=2, CatName = "Garfield", CategoryID=2},
                new Cat { CatID=3, CatName = "Rengar", CategoryID=3}
                  
                );

            builder.Entity<Category>()
            .Property(c => c.CategoryName)
            .IsRequired()
            .HasMaxLength(40);

            builder.Entity<Cat>()
                .HasOne(c => c.Category);
        }
    }
}

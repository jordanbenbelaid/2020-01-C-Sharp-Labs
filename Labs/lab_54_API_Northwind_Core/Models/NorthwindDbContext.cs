using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab_54_API_Northwind_Core
{
    public class NorthwindDbContext : DbContext
    {

        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options)
            :base(options) { }

        //connection string
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;");
        }

        //dbset customer
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace lab_63_ToDo_API_Users_Categories.Models
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext() { }
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
            : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<ToDo> ToDos { get; set; }

        string connectionString =  @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = ToDoDatabase;";

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(user => user.ToDos)
                .WithOne(user => user.User);
            builder.Entity<User>()
                .Property(user => user.UserName)
                .IsRequired();

            //seeding
            builder.Entity<User>().HasData(
                new User { UserID = 1, UserName = "Fred"},
                new User { UserID = 2, UserName = "Johnny"},
                new User { UserID = 3, UserName = "Layla"},
                new User { UserID = 4, UserName = "Tim"},
                new User { UserID = 5, UserName = "Venus"}
                );

            builder.Entity<ToDo>().HasData(
                new ToDo { ToDoID = 1, ToDoName = "Do this"},
                new ToDo { ToDoID = 2, ToDoName = "And do this"},
                new ToDo { ToDoID = 3, ToDoName = "And do this also"}
                
                );
        }
    }
}

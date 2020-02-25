using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace lab_45_entity_core_sql_sqlite
{
    class Program
    {
        static List<User> users = new List<User>();
        static List<Category> categories = new List<Category>();

        static void Main(string[] args)
        {
            //use database
            using (var db = new UserDatabaseContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                var category1 = new Category() { CategoryName = "Admin" };
                var category2 = new Category() { CategoryName = "User" };
                var category3 = new Category() { CategoryName = "Personal" };
                var user1 = new User() { UserName = "Fred", CategoryId = 1 };
                var user2 = new User() { UserName = "Bob", CategoryId = 2 };
                var user3 = new User() { UserName = "Tim", CategoryId = 3 };
                
                db.Categories.AddRange(category1, category2, category3);
                db.Users.AddRange(user1, user2, user3);
                db.SaveChanges();

                users = db.Users.ToList();
                categories = db.Categories.ToList();

            }

            foreach (var item in users)
            {                                                                   //pointer to category
                Console.WriteLine($"{item.UserId,-15} {item.UserName,-15} {item.Category.CategoryName} \n");
            }
                //users.ForEach(u => Console.WriteLine(u.UserName));
                //categories.ForEach(u => Console.WriteLine(u.CategoryName));
            
        }
    }

    public class UserDatabaseContext : DbContext
    {
        //db set to match tables to c# classes
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        //connection string
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //builder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Users;");

            //sqlite table
            builder.UseSqlite("Data Source = test.db");
        }

    }

    public class User
    {
        public int UserId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool? isValid { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }

    public class Category
    {
        public Category()
        {
            Users = new HashSet<User>();
        }

        public int CategoryId { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }


        public virtual ICollection<User> Users { get; set; }
    }
}

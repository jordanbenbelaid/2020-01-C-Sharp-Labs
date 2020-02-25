using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace lab_37_northwind_core
{
    class Program
    { 
        static List<Customer> customers = new List<Customer>();
        static List<Product> products = new List<Product>();
        static List<Category> categories = new List<Category>();
        
        static string CustomersPath = "customers.csv";
        static void Main(string[] args)
        {
            using (var db = new NorthwindDbContext())
            {
                customers = db.Customers.ToList();
                PrintCustomers(customers);
               // Process.Start("EXCEL", CustomersPath);                    //opens excel
            }

            //Linq basic syntax
            using (var db = new NorthwindDbContext())
            {
                //linq basic query syntax
                //would have to cast these objects to list or array to use them
                var customers01 =
                    from customer in db.Customers
                    select customer;

                var customers02 =
                    from customer in db.Customers
                    where customer.City == "London" || customer.City == "Berlin"
                    orderby customer.ContactName descending
                    select customer;

                //print
                PrintCustomers(customers02.ToList());


                Console.WriteLine("Customer details\n");
                Console.WriteLine($"{"Name",-30} {"City",-30} {"Country"}\n");

                //create custom output object
                var customList =
                    from customer in db.Customers
                    select new
                    {
                        Name = customer.ContactName,
                        City = customer.City,
                        Country = customer.Country
                    };
                //custom print
                customList.ToList().ForEach(item => Console.WriteLine($"{item.Name,-30} {item.City,-30} {item.Country}"));

                Console.WriteLine("Customer details\n");
                Console.WriteLine($"{"Name",-30} {"City",-30} {"Country"}\n");
                //output from constructor
                var customList2 =
                    from customer in db.Customers
                    select new CustomObject()
                    {
                        Name = customer.ContactName,
                        City = customer.CompanyName,
                        Country = customer.Country
                    };
                customList2.ToList().ForEach(item => Console.WriteLine($"{item.Name,-30} {item.City,-30} {item.Country}"));


                //grouping items
                //SQL has aggregation (Sum, Count, Max, Min etc)
                //Query via city  ==> count by city

                var customerCountByCity =
                    from customer in db.Customers
                    group customer by customer.City into cities             //groups cities
                    where cities.Count() > 1                    //cities with more than 1
                    orderby cities.Count() descending           //cities put in descending order (for amount of city)
                    select new
                    {
                        City = cities.Key,
                        Count = cities.Count()
                    };
                Console.WriteLine($"\n\nList of customer count by city\n");
                foreach (var item in customerCountByCity.ToList())
                {
                    Console.WriteLine($"{item.City,-20}{item.Count}");
                }

                var customerByCity = db.Customers.ToList().OrderBy(c => c.Country).ThenBy(c => c.City);
                var customersGroupedByCity = db.Customers.ToList()
                    .GroupBy(c => c.City)
                    .Where(item => item.Count() > 1)
                    .OrderByDescending(item => item.Count())
                    .ThenByDescending(item => item.Key);

                Console.WriteLine($"\n\nList of customer count by city\n");
                foreach (var item in customerCountByCity.ToList())
                {
                    Console.WriteLine($"{item.City,-20}{item.Count}");
                }


                //Joining Tables
                //products will have a category and link via category ID

                products =
                    (from p in db.Products
                    select p).ToList();

                //In order to add category name to output, first have to pull
                //in categories into local database store (cache)

                //in LINQ we have lazy loading - query not actually run
                //and bought into memory until we use/need the data
                //var categories = db.Categories => lazy loading
                //.ToList() forced loading
                categories =
                    (from c in db.Categories
                    select c).ToList();

                //print
                PrintProducts(products.ToList());

            }
        }
            
      //  static void PrintCustomers()
      //  {
                //if (File.Exists("customers.csv"))
                //{
                //    File.Delete("customers.csv");
                //}

                ////header line
                //File.AppendAllText("customers.csv", "Customer ID, Contact Name, Company Name, City, Country"+Environment.NewLine);

            //print 5 customers (ID,ContactName,CompanyName, City, Country)
            //customers.ForEach(customer =>
            //{
            //    string customerData = $"{customer.CustomerID},{customer.ContactName},{customer.CompanyName}," +
            //                            $"{customer.City},{customer.Country}\n";
            //    //output to csv
            //    Console.WriteLine($"{customerData}\n");
            //    File.AppendAllText("customers.csv", customerData);
            //});

            //overloading the method lets us use our new method in this method

            //print global customer list
          //  PrintCustomers(customers);
      //  }
        static void PrintProducts(List<Product> products)
        {
            Console.WriteLine($"\n\n{"Product ID",-15} {"Product Name",-30} {"Category ID",-15} {"Unit Price",-15} {"Units In Stock"}\n");
            //ID,Name,category id,unitprice,untisinstock            
            products.ForEach(p => Console.WriteLine($"\n{p.ProductID,-15}{p.ProductName,-35}{p.Category.CategoryName,-30}{p.CategoryID,-15}" +
                                                    $"{p.UnitPrice,-15}{p.UnitsInStock}\n"));

        }    
        static void PrintCustomers(List<Customer> customers)
        {
            if (File.Exists("customers.csv"))
            {
                File.Delete("customers.csv");
            }

            //header line
            File.AppendAllText("customers.csv", "Customer ID, Contact Name, Company Name, City, Country" + Environment.NewLine);

            //print 5 customers (ID,ContactName,CompanyName, City, Country)
            customers.ForEach(customer =>
            {
                string customerData = $"{customer.CustomerID},{customer.ContactName},{customer.CompanyName}," +
                                        $"{customer.City},{customer.Country}\n";
                //output to csv
                Console.WriteLine($"{customerData}\n");
                File.AppendAllText("customers.csv", customerData);
            });
        }
    }

    class CustomObject
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public CustomObject(string name, string city, string country)
        {
            this.Name = name;
            this.City = city;
            this.Country = country;
        }
        public CustomObject()
        {

        }
    }


     public class DatabaseTests
    {
        static List<Customer> customerList = new List<Customer>();
        public int Tests()
        {
            using (var db = new NorthwindDbContext())
            {
                customerList = db.Customers.ToList();
            }

                return customerList.Count;
        }

        public int Tests2()
        { 

            using (var db = new NorthwindDbContext())
            {
                customerList = db.Customers.ToList();
            }

            var customer = new Customer()
            {
                CustomerID = "Phil2",
                CompanyName = "Sparta"
            };

            using (var db = new NorthwindDbContext())
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                customerList = db.Customers.ToList();
            }
            return customerList.Count;
        }

        public int Tests3()
        {
            using (var db = new NorthwindDbContext())
            {
                var deleteItem = db.Customers.Find("Phil2");
                db.Customers.Remove(deleteItem);
                db.SaveChanges();
                customerList = db.Customers.ToList();
            }
            return customerList.Count;
        }

        public int ProductTest()
        {
            List<Product> productList = new List<Product>();

            using (var db = new NorthwindDbContext())
            {
                productList = db.Products.ToList();
            }

            return productList.Count;
        }
    }
}
    //talks to the database

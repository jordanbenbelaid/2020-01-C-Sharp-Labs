using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_36_Northwind_code_first
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();

            var customer01 = new Customer();
            customer01.CustomerID = "CUST1";
            customer01.ContactName = "Customer Fred";
            customer01.Print();

            List<Product> products = new List<Product>();

            //get customers
            using (var db = new NorthwindModel())
            {
                //getting lists of products and customers
                customers = db.Customers.ToList();
                products = db.Products.ToList();
                //delete file if already exists
                if (File.Exists("customers.csv"))
                {
                    File.Delete("customers.csv");
                }

                //header line
                File.AppendAllText("customers.csv", "Customer, Name\n");
                //get the customers: list of customers = get the database, get all customers, put them in the list 

                //print customers and products using .Print()
                customers.ForEach(customer => customer.Print());                
                products.ForEach(product => product.Print());

                Process.Start("EXCEL","customers.csv");

            }
        }
    }

    //Can add to customer class (partial class)
    partial class Customer
    {
        public void Print()
        {
            string content = $"{this.CustomerID} , {this.ContactName}\n";
            //print customer
            Console.WriteLine(content);
            File.AppendAllText("customers.csv", content);
        }
    }

    partial class Product
    {
        public void Print()
        {
            Console.WriteLine($"{this.ProductID} has name {this.ProductName}");
        }
    }

}

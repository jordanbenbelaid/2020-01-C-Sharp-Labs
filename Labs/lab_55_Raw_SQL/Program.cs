using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace lab_55_Raw_SQL
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;")) 
            {
                connection.Open();
                Console.WriteLine(connection.State);

                var sqlQuery = "select * from customers";

                //send command to database
                using(var command = new SqlCommand(sqlQuery,connection))
                {
                    //read data
                    var sqlreader = command.ExecuteReader();

                    //while (sqlreader has records coming in)
                    while (sqlreader.Read())
                    {
                        string CustomerId = sqlreader["CustomerID"].ToString();
                        string ContactName = sqlreader["ContactName"].ToString();
                        string CompanyName = sqlreader["CompanyName"].ToString();
                        string City = sqlreader["City"].ToString();

                        var customer = new Customer()
                        {
                            CustomerID = CustomerId,
                            ContactName = ContactName,
                            CompanyName = CompanyName,
                            City = City

                        };
                        customers.Add(customer);
                    }
                }
            }

            //print customers
            customers.ForEach(customer => Console.WriteLine($"{customer.CustomerID,-20}{customer.ContactName,-25}" +
                $"{customer.CompanyName,-40}{customer.City}"));
        }
    }
}

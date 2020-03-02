using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace lab_58_serialization
{
    class Program
    {
        //lab
        //create a list of 2 customers 
        //convert (serialize) to JSON and print JSON on console
        //library NewtonSoft.Json

        //Get data
        //Use httpClient to get JSON as a string from 
        //https://raw.githubusercontent.com/philanderson888/data/master/customers.json
        //deserialize to List<Customer> and print the list to Console

        static List<Customer> customer = new List<Customer>();
        static List<Customer> JsonCustomer = new List<Customer>();

        static void Main(string[] args)
        {
            AddCustomer();
            GetJsonData();
             
        }

        static void AddCustomer()
        {
            Customer customer1 = new Customer();
            Customer customer2 = new Customer();

            customer1.CustomerID = 1;
            customer1.CustomerName = "John";
            customer1.Address = "56 john street";
            customer.Add(customer1);

            customer2.CustomerID = 2;
            customer2.CustomerName = "Jake";
            customer2.Address = "22 jake street";
            customer.Add(customer2);

            var output = System.Text.Json.JsonSerializer.Serialize(customer);

            Console.WriteLine(output);
        }

        static void GetJsonData()
        {
            var url = new Uri("https://raw.githubusercontent.com/philanderson888/data/master/customers.json");
            var webclient = new WebClient { Proxy = null };
            var jsonData = webclient.DownloadString(url);

            JsonCustomer = JsonConvert.DeserializeObject<List<Customer>>(jsonData);

            JsonCustomer.ForEach(i => Console.WriteLine($"{i.CustomerName,-20} {i.CustomerID,-20} {i.Address,-20}"));
        }
    }

    
    class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
    }
}

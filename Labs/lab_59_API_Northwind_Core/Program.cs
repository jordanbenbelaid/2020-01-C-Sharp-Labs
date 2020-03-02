using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Threading;
using System.Reflection.Metadata.Ecma335;

namespace lab_59_API_Northwind_Core
{
    class Program
    {

        static List<Customer> customers = new List<Customer>();
        static Customer customer = new Customer();
        static string url = "https://localhost:44335/api/Customers";
        static Stopwatch s = new Stopwatch();
        static long SynchronousTime = 0;
        static HttpClient httpclient = new HttpClient();
        static void Main(string[] args)
        {
            Thread.Sleep(10000);
            s.Start();

            // Get customers from API Synchronously
            GetCustomers();

            SynchronousTime = s.ElapsedMilliseconds;
            Console.WriteLine($"\n\nFinished Synchronous Call At {s.ElapsedMilliseconds}\n\n");

            // Get customers Async !!!

            GetCustomersAsync();

            Console.WriteLine($"\n\nMain Method Did Not Wait For Asynchronous Call - Program Finished At {s.ElapsedMilliseconds}\n\n");

            // Add a new customer synchronously
            var customer = new Customer()
            {
                CustomerID = "Phil2",
                ContactName = "Test Customer",
                CompanyName = "Sparta Test",
                City = "London",
                Country = "UK"
            };
            //HttpResponseMessage response = PostCustomer(customer);
            //Console.WriteLine($"We have successfully added customer with HTTP Response Status code " +
            //$"{response.IsSuccessStatusCode} ");

            var customer2 = new Customer()
            {
                CustomerID = "Phil3",
                ContactName = "Test Customer",
                CompanyName = "Sparta Test",
                City = "London",
                Country = "UK"
            };

            PostCustomerAsync(customer2);

            Console.ReadLine();
        }

        static void GetCustomers()
        {
            using (var client = new HttpClient())
            {
                var jsonStringTask = client.GetStringAsync(url);
                customers = JsonConvert.DeserializeObject<List<Customer>>(jsonStringTask.Result);
            }
            customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-10}" +
                $"{c.ContactName,-25}{c.CompanyName,-30}{c.City,-20}{c.Country}"));

        }

        static async void GetCustomersAsync()
        {
            using (var client = new HttpClient())
            {
                var jsonString = await GetCustomerDataAsync(url);
                customers = JsonConvert.DeserializeObject<List<Customer>>(jsonString);
                customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-10}" +
                    $"{c.ContactName,-25}{c.CompanyName,-30}{c.City,-20}{c.Country}"));
                Console.WriteLine($"\n\nFinished Getting Asynchronous Data At {s.ElapsedMilliseconds}\n\n");

                Console.WriteLine($"It took {SynchronousTime} to get our data synchronously.\n" +
                    $"It took {s.ElapsedMilliseconds} to get our data asynchronously\n" +
                    $"Async was faster by {s.ElapsedMilliseconds - SynchronousTime} milliseconds");
            }
        }

        static async Task<string> GetCustomerDataAsync(string url)
        {
            string jsonString = null;

            using (var client = new HttpClient())
            {
                jsonString = await client.GetStringAsync(url);
            }
            return jsonString;
        }

        static HttpResponseMessage PostCustomer(Customer customer)
        {
            string customerAsJson = JsonConvert.SerializeObject(customer);
            var HttpContent = new StringContent(customerAsJson);
            HttpContent.Headers.ContentType.MediaType = "application/json";
            HttpContent.Headers.ContentType.CharSet = "UTF-8";

            var responseMessage = httpclient.PostAsync(url, HttpContent);

            return responseMessage.Result;
        }

        static async Task PostCustomerAsync(Customer customer)
        {
            var responseMessage = await PostCustomerDataAsync(customer);
            Console.WriteLine($"We have successfully added customer with HTTP Response Status code " +
               $"{responseMessage.IsSuccessStatusCode} ");

        }

        static async Task<HttpResponseMessage> PostCustomerDataAsync(Customer customer)
        {
            string customerAsJson = JsonConvert.SerializeObject(customer);
            var HttpContent = new StringContent(customerAsJson);
            HttpContent.Headers.ContentType.MediaType = "application/json";
            HttpContent.Headers.ContentType.CharSet = "UTF-8";

            var responseMessage = await httpclient.PostAsync(url, HttpContent);

            return responseMessage;
        }

        static async void PutCustomerAsync(string ID, string name, string CompanyName, string City, string Country)
        {
            var responseMessage = await PutCustomerDataAsync(ID, name, CompanyName, City, Country);
            Console.WriteLine($"Customer {ID} updated and gives a response message of {responseMessage.IsSuccessStatusCode}");
        }

        static async Task<HttpResponseMessage> PutCustomerDataAsync(string ID, string name, string CompanyName, string City, string Country)
        {
            using (var client = new HttpClient())
            {
                var customerString = await GetCustomerDataAsync(url.ToString() + $"/{ID}");
                //add customer
                customer = JsonConvert.DeserializeObject<Customer>(customerString);
                string customerJson = JsonConvert.SerializeObject(customer);
                var HttpContent = new StringContent(customerJson);
                HttpContent.Headers.ContentType.MediaType = "application/json";
                HttpContent.Headers.ContentType.CharSet = "UTF-8";

                var response = await client.PutAsync(url + $"/{customer.CustomerID}", HttpContent);
                return response;
            }
        }
    }
}

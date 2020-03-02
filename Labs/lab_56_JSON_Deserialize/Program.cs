using System;
using System.Collections.Generic;

namespace lab_56_JSON_Deserialize
{
    class Program
    {
        List<Customer> customers = new List<Customer>();
        static string url = "https://localhost:44392/api/Customers";
        static void Main(string[] args)
        {
            //Get customers from API synchrounously
            GetCustomers();

            //Get customers Async


        }

        static void GetCustomers()
        {

        }
    }
}

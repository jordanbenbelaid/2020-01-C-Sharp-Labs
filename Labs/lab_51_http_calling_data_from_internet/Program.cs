using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace lab_51_http_calling_data_from_internet
{
    class Program
    {
        //static Uri url = new Uri("https://www.google.com");
        static Uri url = new Uri("https://raw.githubusercontent.com/philanderson888/data/master/customers.json"); 
        static Uri url02 = new Uri("https://www.york.ac.uk/teaching/cws/wws/webpage1.html");
        static void Main(string[] args)
        {
            //get webpage synchronously
            Console.WriteLine("Program has started");
            //GetData();
            //GetDataAsync();
            GetDataJson();
            Console.WriteLine("Program has ended");
            Console.ReadLine();
        }

        static void GetData()
        {
            //proxy is used as an agent middleman computer (not used here)
            var webclient = new WebClient { Proxy = null };
            webclient.DownloadFile(url,"myWebPage.html");
            // print to screen 
            //Console.WriteLine(File.ReadAllText("myWebPage.html"));
        }

        static async void GetDataAsync()
        {
            //repeat async
            var webclient = new WebClient { Proxy = null };
            //webclient.DownloadFileAsync(url02, "myWebPage2.html");      //missing async keyword
            //Console.WriteLine(File.ReadAllText("myWebPage2.html"));
            var myWebPage3 = await webclient.DownloadStringTaskAsync(url02);
            File.WriteAllText("myWebPage3.html", myWebPage3);
            Console.WriteLine(myWebPage3);
        }

        static void GetDataJson()
        {
            var url = new Uri("https://localhost:44392/api/Customers");
            var webclient = new WebClient { Proxy = null };
            var jsonData = webclient.DownloadString(url);
            Console.WriteLine(jsonData);

        }

        async Task<string> GetStringAsync()
        {
            return null;
        }
    }
}

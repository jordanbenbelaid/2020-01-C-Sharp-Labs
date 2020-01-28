using System;
using System.Diagnostics;
using System.Threading;

namespace lab_30_stopwatch_date_time
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Stopwatch();
            
            s.Start();
            Thread.Sleep(1000);         //milliseconds

            int bigNumber = 1_000_000;
            int total = 0;

            //nested loop to break system
            //for (int i = 0; i < bigNumber; i++)
            //{
            //    total += i;
            //    for (int j = 0; j < bigNumber; j++)
            //    {
            //        total += i;
            //        for (int k = 0; k < bigNumber; k++)
            //        {
            //            total += i;
            //        }

            //    }
            //    total += i;
            //}
           
            s.Stop();

            //Dates

            Console.WriteLine(s.Elapsed);           //HH:MM:SS.1234567
            Console.WriteLine(s.ElapsedMilliseconds);       //10^-3 seconds
            Console.WriteLine(s.ElapsedTicks);          //10^-7 seconds

            var date01 = new DateTime();
            Console.WriteLine($"default data is {date01}");

            var date02 = DateTime.Today;
            var date03 = DateTime.Now;

            var date04 = new DateTime(2019,12,12,05,05,00);         //literal year,month,day,hour,minute,seconds

            //Change time
            var tomorrow = date02.AddDays(1);
            var nextWeek = date02.AddDays(7);

            var timeSpan = nextWeek - date02;

            Console.WriteLine(timeSpan.ToString());

            //Printing the Date
            Console.WriteLine(tomorrow.ToShortDateString());
            Console.WriteLine(tomorrow.ToLongDateString());
            Console.WriteLine(tomorrow.ToString("dd-MM-yyyy"));
            Console.WriteLine(tomorrow.ToString("dd-mm-yyyy"));
            Console.WriteLine(tomorrow.ToString("dd-mm-yy"));
            Console.WriteLine(tomorrow.ToString("dd-mm-yyyy"));
            Console.WriteLine(tomorrow.ToString("dd-MM-yyyy HH:mm"));
            Console.WriteLine(tomorrow.ToString("dd-MM-yyyy HH:mm:ss"));

        }
    }
}

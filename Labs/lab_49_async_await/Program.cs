using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace lab_49_async_await
{
    class Program
    {

        static List<string> fileRows = new List<string>();
        static void Main(string[] args)
        {
            //standard code is SYNCHRONOUS IE LINE BY LINE, THREAD IS ONLY ONE THREAD
            // AND IT 'HANGS' if you have long operations
            var s = new Stopwatch();
            s.Start();
            Console.WriteLine($"Starting stopwatch at time {s.ElapsedMilliseconds}");

            DoThis();
            Console.WriteLine(s.ElapsedMilliseconds);



            //async operation
            //main thread will start the operation but not wait for it.    main thread will not pause

            //build a big text file
            File.Delete("log.dat");
            Console.WriteLine("\n\nBuilding text file\n\n");

            for (int i = 0; i < 10000; i++)
            {
                File.AppendAllText("log.dat", $"New log entry {i} at {DateTime.Now}\n\n");
            }
            Console.WriteLine("File built . . .");
            Console.WriteLine($"Starting async operations at{s.ElapsedMilliseconds}");
            ReadTextLines();        //async
            Console.WriteLine($"Finishing async operations at{s.ElapsedMilliseconds}");
            Console.WriteLine("Program has completed");
            Console.ReadLine();         //hang the program 
        }

        static void DoThis()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Finished doing this");
        }

        static async void ReadTextLines()
        {
            var array = await File.ReadAllLinesAsync("log.dat");
            fileRows.AddRange(array);           //add array to list
                                                //print sample (every 1000 lines

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace lab_50_tasks
{
    class Program
    {

        static Stopwatch s = new Stopwatch();
        static void Main(string[] args)
        {
            //Main thread here

            //Create backgorund task
            //New task spawns a new thread (cpu controls memory, speed etc)
            //Argument is delegate type
            //Lambda => create anonymous delegate type
            //      () input parameters
            //      {} code body
            //      => method with no name

            var task01 = new Task(() => {
                Console.WriteLine("Running Task01");

                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"task01 in process of printing {i} at {s.ElapsedMilliseconds}");
                }                
            }  );

            //Create a stopwatch to see whats happening
            s.Start();
            Console.WriteLine($"Calling task01 at time {s.ElapsedMilliseconds}");
            task01.Start();

            //also do some synchronous work on main thread
            for (int j = 0; j < 100; j++)
            {
                Console.WriteLine($"\t\t\t\t\ttask01 in process of printing {j} at {s.ElapsedMilliseconds}");
            }


            //Task.Run
            var task02 = Task.Run(() => { Console.WriteLine($"\t\t\t\t\tTask02 is running at {s.ElapsedMilliseconds}"); });
            var task03 = Task.Run(() => { Console.WriteLine($"\t\t\t\t\tTask03 is running at {s.ElapsedMilliseconds}"); });
            var task04 = Task.Run(() => { Console.WriteLine($"\t\t\t\t\tTask04 is running at {s.ElapsedMilliseconds}"); });

            //Older Variants
            var task05 = Task.Factory.StartNew(() => { Console.WriteLine("Running in a task factory"); });

            //array of task
            var taskArray01 = new Task[3];
            //individual tasks in this array
            taskArray01[0] = Task.Run(() => 
            {
                Thread.Sleep(1500);
                Console.WriteLine($"\t\t\t\t\tFirst task in array took {s.ElapsedMilliseconds} long to run"); 
            });
            taskArray01[1] = Task.Run(() => 
            {
                Thread.Sleep(1500);
                Console.WriteLine($"\t\t\t\t\tSecond task in array took {s.ElapsedMilliseconds} long to run"); 
            });
            taskArray01[2] = Task.Run(() => 
            {
                Thread.Sleep(1500);
                Console.WriteLine($"\t\t\t\t\tThird task in array took {s.ElapsedMilliseconds} long to run"); 
            });

            //Waiting for tasks
            //can wait for at least one array task to
            Task.WaitAny(taskArray01);

            //or all
            Task.WaitAll(taskArray01);
            Console.WriteLine($"First half of program ends at time {s.ElapsedMilliseconds}");

            //returning data from a task


            //reset stopwatch
            s.Restart();
            var task06 = Task<string>.Run(() => 
            {
                return "task06 returns a string";
            });

            Console.WriteLine(task06.Result);

            //running multiple name emthods in parallel
            //imagine 20 nightly/cleanup jobs every night
            //USEFUL IF ORDER OF EXECUTION DOESNT MATTER : RUN IN PARALLEL (TOGETHER)
            Parallel.Invoke(() =>
            {
                NightRunTask01();
                NightRunTask02();
                NightRunTask03();
                NightRunTask04();
            });

            //Can run tasks to run one, then the other

            //Running for/foreach loop in parallel
            //for loop
            Console.WriteLine("\n\n\nRunning For Loop in Parallel");
            Parallel.For(0, 100, i => 
            {
                Console.WriteLine($"Running task {i} in a loop");
            });

            Console.WriteLine("\n\nAlso run a parallel FOREACH loop");
            var myArray = new string[] { "first", "second", "third" };
            Parallel.ForEach(myArray, (item) =>
             {
                 Console.WriteLine($"Printing item {item}");
             });

            //ENTITY LINQ DATABASE READS IN PARALLEL TO GET LOTS OF INFO AT SAME TIME
            //Previously we ran ENTITY in SERIAL
            var customersFromDatabase = new List<Customer>();
            var customers = customersFromDatabase.AsParallel();             //execute query in parallel

            Console.WriteLine($"Program ends at time {s.ElapsedMilliseconds}");
            Console.ReadLine();
        }

        static void NightRunTask01() { Console.WriteLine("Running night time maintenance task01"); }
        static void NightRunTask02() { Console.WriteLine("Running night time maintenance task02"); }
        static void NightRunTask03() { Console.WriteLine("Running night time maintenance task03"); }
        static void NightRunTask04() { Console.WriteLine("Running night time maintenance task04"); }
    }

    class Customer
    {

    }
}

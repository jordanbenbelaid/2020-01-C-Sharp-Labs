using System;
using System.IO;
using System.Diagnostics;

namespace lab_11_methods
{
    class Program
    {
        static void Main(string[] args)
        { 
            DoThis();
            DoThis(100);
            DoThis("Hi");
            DoThis(100, "Hi", true, DateTime.Now);
            DoThis(100, "Hi", true, DateTime.Now, 10000, 10000);    //set optional components at the end

            DoThis(x: 100, y: "Hi", z: true, DateTime.Now);    // named parameters
            DoThis(z: true, time:DateTime.Now, x: 100, y: "Hi");    // named parameters
        }

        //overloading methods : same name different parameters
        static void DoThis() { Console.WriteLine("No Parameters"); }
        static void DoThis(int x) { Console.WriteLine($"Integer {x}"); }
        static void DoThis(string y) { Console.WriteLine($"String {y}"); }
        static void DoThis(int x, string y, bool z, DateTime time)
        {
            Console.WriteLine($"{x,-5}{y,-5}{z,-10}{time,-25}");
        }
        static void DoThis(int x, string y, bool z, DateTime time, int opt1 = 1000, int opt2 = 1000)
        {
            string output = $"{x,-5}{y,-5}{z,-10}{time,-25}{opt1,-15}{opt2}";
            Console.WriteLine($"{x,-5}{y,-5}{z,-10}{time,-25}{opt1,-15}{opt2}");
            //save as text
            File.AppendAllText("output.txt", output);
            //save as CSV (Comma Seperated Values)
            string csvoutput = $"{x,-5},{y,-5},{z,-10},{time,-25},{opt1,-15},{opt2}";
            File.AppendAllText("output.csv", csvoutput);
            //view as spreadsheet
            Process.Start(@"C:\Program Files (x86)\Microsoft Office\root\Office16\excel.exe", "output.csv");
        }
    }
}

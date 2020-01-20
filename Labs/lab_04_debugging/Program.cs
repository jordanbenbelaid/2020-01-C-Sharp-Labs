using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace lab_04_debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText(@"c:\Log\log.dat", "");
            int x = 10;
            x = x + 10;
            int y = x * x;
            Console.WriteLine(x);
            Console.WriteLine(y);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                Trace.WriteLine($"Trace WriteLine {i}");
                Debug.WriteLine($"Debug Writeline {i}");
                Debug.WriteLineIf(i == 6, "Hey, i is 6!!");
                File.AppendAllText("..\\log.dat",$"Logging i = {i} at {DateTime.Now}");
                Console.WriteLine("\\"); // backslash is an 'escaped character
                File.AppendAllText(@"c:\Log\log.dat",$"\nLogging i = {i} at {DateTime.Now}");
                // '\' is a special character
                // use '@' symbol to provide clean string 'literal' (can use double \\)
                Thread.Sleep(1500);
            }
            //print file 
            var logFilePath = @"c:\Log\log.dat";
            Console.WriteLine("\n\nPrinting contents of log file\n\n");
            Console.WriteLine(File.ReadAllText(logFilePath));
        }
    }
}

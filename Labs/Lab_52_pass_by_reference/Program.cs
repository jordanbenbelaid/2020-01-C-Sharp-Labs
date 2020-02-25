using System;

namespace Lab_52_pass_by_reference
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"\nFirst run - Integer is privately handled inside method\n\n");
            int x = 10;
            DoThis(x);
            Console.WriteLine($"x is {x}");
            //PASS IN INTEGER BUT TRACK VALUE INSIDE METHOD
            //PASS BY REFERENCE
            Console.WriteLine($"\n\nSecond run - Track integer inside method (pass by reference)\n");
            TrackThis(ref x);
            Console.WriteLine($"In Main Method x is {x}");
        }

        //PRIVATE USE OF X (UNRELATED TO X PASSED IN)
        static void DoThis(int x)
        {
            x = x + 10;
            Console.WriteLine($"x is {x}");
        }

        static void TrackThis(ref int x)
        {
            x += 1000;
            Console.WriteLine($"Inside Method x is {x}");
        }
    }
}

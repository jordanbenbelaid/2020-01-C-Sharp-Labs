﻿using System;

namespace lab_29_variables_continued
{
    class Program
    {
        static void Main(string[] args)
        {
            string string01 = "hi";      //YES!!
            var string02 = new String("hi");

            var point01 = new PointOnGraph(10,10);
            var point02 = new PointOnGraph(20,20);
            var point03 = new PointOnGraph(30,30);

            //String formatting
            double num01 = 1.234567;
            double num02 = 7.898989;
            double long01 = 123456789;

            Console.WriteLine($"Here are some numbers");
            Console.WriteLine($"No decimal places {num01,5:N0}{num02,10:N0}");
            Console.WriteLine($"1 DP {num01,-5:N1}{num02,-10:N1}");
            Console.WriteLine($"2 DP {num01,-5:N2}{num02,-10:N2}");
            Console.WriteLine($"3 DP {num01,-5:N3}{num02,-10:N3}");
            Console.WriteLine($"Currency {num01,-5:C}{num02,-10:C}");
            Console.WriteLine($"Exponential {long01,-10:E}");
        }
    }

    class SomeClass { }

    struct PointOnGraph
    {
        public int x;
        public int y;
        
        //constructor
        public PointOnGraph(int x, int y)
        {
            this.x = x;     //'this' refers to instance
            this.y = y;
        }
    }
}

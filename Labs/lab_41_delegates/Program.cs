using System;

namespace lab_41_delegates
{
    class Program
    {
        public delegate void Delegate01();
        public delegate void Delegate03(int x, int y);
        static void Main(string[] args)
        {
            //var delegate01 = new Delegate();

            var delegate02 = new Delegate01(Method01);
            delegate02 += Method02;
            delegate02 += Method03;

            //Nothing is running
            //To run, can call delegate with brackets
            delegate02();

            var delegate03 = new Delegate03(Method04);
            delegate03(10,100);

            //Most common delegate type is type of void MyDelegate();
            //I.e   no inputs, no outputs   ==> action delegate

            var delegate04 = new Action(Method01);
            //often see the word Action() in code ==> pointer to method types of void DoThis();

        }

        static void Method01() { Console.WriteLine("In Method01"); }

        static void Method02() { Console.WriteLine("In Method02"); }
        
        static void Method03() { Console.WriteLine("In Method03"); }

        static void Method04(int x, int y) { Console.WriteLine($"Method04 inputs are {x} and {y}"); }
    }
}

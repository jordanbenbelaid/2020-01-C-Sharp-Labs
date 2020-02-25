using System;

namespace lab_42_events
{
    class Program
    {

        public delegate string MyDelegate(string x, string y);
        public static event MyDelegate MyEvent;

        static void Main(string[] args)
        {
            //Add Methods
            //Outputs the latest
            MyEvent += DoThis;
            MyEvent += DoThat;
            MyEvent += DoThis;

            //Nothing happens yet
            Console.WriteLine(MyEvent("Fred", "Flinstone"));
        }

        static string DoThis(string a, string b)
        {
            return "Hello" + a + " " + b;
        }

        static string DoThat(string a, string b)
        {
            return "Goodbye" + a + " " + b;
        }
    }
}

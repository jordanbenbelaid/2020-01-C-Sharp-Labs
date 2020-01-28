using System;

namespace lab_34_tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            DoThis();           //Action ie Sends no parameters, returns nothing
            string output = AlsoDoThis();

            string output3;
            string output2 = AndThisAlso(out output3);

            var output5 = FinallyThis();
            Console.WriteLine(output5.output6);
            Console.WriteLine(output5.output7);
        }

        static void DoThis()
        {
            Console.WriteLine("I am doing this");
        }

        static string AlsoDoThis()
        {
            return "I am also doing this";
        }

        static string AndThisAlso(out string output3)
        {
            output3 = "Even this as well";
            return "And this also";
        }

        //TUPLES are anonymous objects, that can be optionally given a name
        static (string output6,int output7) FinallyThis()
        {
            return ("Finally this", 2000);
        }
    }
}

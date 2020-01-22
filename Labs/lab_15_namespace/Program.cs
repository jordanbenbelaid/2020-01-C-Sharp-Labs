using System;

namespace lab_15_namespace
{
    class Program
    {
        static void Main(string[] args)
        {
            var instanceA = new A.X();
            var instanceB = new A.X();

            Console.WriteLine(instanceA.Message);
            Console.WriteLine(instanceB.Message);
        }
    }
}

    namespace A
    {
        class X
        {
            internal string Message = "X in A";
        }
    }

    namespace B
    {
        class X
        {
            internal string Message = "X in B";
        }
    }

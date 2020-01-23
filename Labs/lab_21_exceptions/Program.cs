using System;

namespace lab_21_exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //StackOverflow();
            //crashes the system (STACK OVERFLOW)

            //void StackOverflow()
            //{
            //    Console.WriteLine("Soon to crash");
            //    StackOverflow();
            //}

            int x = 10;
            int y = 20;
            int a = 0;

            //int trouble = y / a;      Unhandled

            try
            {
                double z = x / y;
                double d = x / y;
                Console.WriteLine($"{x}/{y} is {z} and {d}");
                int trouble2 = y / a;            //Handled              
            }

            catch(Exception e)
            {
                //Console.WriteLine("Houston, we have a problem");
                //Console.WriteLine(e);
                //Console.WriteLine(e.Data);
                //Console.WriteLine(e.Message);
            }

            finally
            {
                Console.WriteLine("All good");
            }
        }


    }
}

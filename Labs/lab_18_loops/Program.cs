using System;

namespace lab_18_loops
{
    class Program
    {
        static void Main(string[] args)
        {
            //for..
            for(int i = 1; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            //foreach..
            string animal = "Monkey";
            foreach (char a in animal)
            {

            }
            //while
            int x = 0;
                while (x < 10)
            {
                x++;
            }

            //do.while
            int y = 1;
            do
            {
                y++;
            }
            while (y < 20);

            //multiple of 5's until 90

            for (int n = 1; n <= 100; n++)
            {
                if (n % 5 != 0) continue;
                Console.WriteLine(n);
                if (n == 90) break;
            }

            //return
            //if we are in a method we can exit the loop and method at the same time using return
            DoThis();
            void DoThis()
            {
                for (int h = 1; h < 100; h++)
                {
                    if (h == 10) return;
                    Console.WriteLine($"In method DoThis - h is {h}");
                }
            }

            //Throw
            //In some bigger applications, they want to track when errors occur (eg form validation)

            for(int num = 0; num < 10; num++)
            {
                if (num == 5)
                {
                    throw new Exception("Invalid number");
                }
            }
        }
    }
}

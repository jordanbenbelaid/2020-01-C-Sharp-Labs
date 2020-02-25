using System;
using System.Collections;

namespace lab_38_operators
{
    class Program
    {
        static void Main(string[] args)
        {
            //Unary
            //Increment ++ or --
            //be wary of this operator - safe rule = always use it on standalone line

            int x = 10;
            
            //read the line below as y=x (y=10), then increment x to 11
            int y = x++;            //y=11

            Console.WriteLine($"x is {x}, y is {y}");

            //z = increment y first from 10 to 11 (z = 11)
            int z = ++y;

            //what are the values of y and z
            Console.WriteLine($"x is {x}, y is {y} and z is {z}");

            //! not operator
            var isValid = false;
            isValid = !isValid;         //flip boolean
            Console.WriteLine(isValid);


            //Binary operators
            //BIDMAS/BODMAS
            //MODULUS = REMAINDER
            //can easily seperate fractional parts
            //3      4/5  => 19/5
            int a = 19;
            int b = 5;

            Console.WriteLine(a/b);        //integer division
                                           //truncates
            Console.WriteLine(a%b);        //shows the remainder of the division

            //one input must be decimal for output to be decimal

            int c = 19;
            double d = 5.0;         //affect output

            Console.WriteLine(c/d);             //accurate decimal

            //&& AND     || OR
            //short circuit

            if (false && false) { }             //will not check second operator (predetermined result)

            if (true || true) { }               //will not check second operator (predetermined result)

            if (true ^ false) { }               //XOR will return true
            if (true ^ true) { }                //          false

            //Ternary operator
            if (1 == 1) { }
            else { }

            //replace with
            var output = (1 == 1) ? "output this if true" : "output this if false";

           

        }
    }

    //class Test : IEnumerable
    //{
    //    //must implement GetEnumerator
    //    int GetEnumerator();
    //}
}

using System;

namespace lab_24_variables
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 100;
                num1 = -100;
            uint num2 = 200;
            //    num2 = -200; not allowed

            //decimals
            //float
            var num3 = 200.0f;      //32 bits
            //double
            var num4 = 200.0;    //default : 64 bits long (USE THIS)
            //decimal
            var num5 = 200.0m;      //128 bits precision (use for money)

            //OVERFLOW
            //Care!! Integers will take wrong value
            //Decimals will truncate
            //Integers
            int bigNumber = int.MaxValue;       //2 billion ish
            Console.WriteLine(bigNumber);
            bigNumber = bigNumber * 10;
            Console.WriteLine(bigNumber);
            checked
            {
                //check for big numbers (not on by default)
            }

            //Decimals - they TRUNCATE
            var num6 = 1.2345678901234567890123456789012345678901;
            Console.WriteLine($"Long number prints as {num6}");

            //Exponential values
            Console.WriteLine($"Max double value is {double.MaxValue}");        //10^300

            //Care with decimal equivalents
            double num7 = 0.1;
            double num8 = 0.2;
            if (num7 + num8 == 0.3)
            {
                Console.WriteLine("Numbers match");
            }
            Console.WriteLine(num7 + num8);

            //0.1 (ie decimals) stored non-precisely in binary
            if(Math.Abs(num8 - num7) < 0.00001)
            {
                Console.WriteLine("Numbers match to 5 decimal points");
            }

            //char
            char char01 = 'f';  //Single quote
            Console.WriteLine(char01);
            Console.WriteLine((int)char01);         //ASCII Number
            //other way
            Console.WriteLine((char)103);           //ASCII ==> character g 

            //string
            //string is an array of chars
            string myName = "Jordan";
            Console.WriteLine(myName[1]);       //O
            //all
            foreach (char c in myName) 
            {
                Console.WriteLine(c);
            }

            for (int i = 0; i < myName.Length; i++)
            {
                Console.WriteLine(myName[i]);
            }

            //bit       1/0
            bool isAwake = true;

            //byte      8 bits
            byte byte01 = 0;
            byte byte02 = 255;      //max       numbers expressed as RGB (red green blue)
            // not allowed, 255 is max          byte byte02 = 256;
            byte byte03 = 0b_1010_1010;         //Binary Literal        1010 represents hexadecimal 10 hex A
            byte byte04 = 0xAA;                 //0x - what follows is HEX                




        }
    }
}

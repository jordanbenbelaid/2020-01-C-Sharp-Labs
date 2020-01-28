using System;

namespace lab_31_Enum
{
    class Program
    {
        static void Main(string[] args)
        {
            // enum good for items not changing
            // days of week
            // monthd of year
            var fruit01 = Fruit.Apple;
            Console.WriteLine(fruit01);             //output apple
            Console.WriteLine((int)fruit01);        // outputs 0
            Console.WriteLine($"How many fruits?  {(int)Fruit.Count}");
            
            //enums can be used sometimes in the powers of 2 to generate codes
            //READ=1, WRITE = 2, EXECUTE (RUN) = 4
        }
    }

    enum Fruit
    {
        Apple, Pear, Lemon, Strawberry, Count
    }

    enum Vegetables
    {
        Onion, Leek, Potato, Turnip
    }

    enum Permissions
    {
        read = 1, write = 2, execute = 4
    }
}

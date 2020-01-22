using System;

namespace lab_17_value_reference_type
{
    class Program
    {
        static void Main(string[] args)
        {
            //copy integer : what happens
            int x = 100;
            int y = x;

            x = 1000;
            Console.WriteLine($"x is {x} & y is {y}");
            //copy array : what happens when we change values

            int[] array1 = { 100, 200, 300 };
            int[] array2;
            Console.WriteLine(array1[0]);       //100
            array2 = array1;
            Console.WriteLine(array2[0]);       //100

            array1[0] = 400;
            Console.WriteLine(array1[0]);           //400
            Console.WriteLine(array2[0]);           //400

            //create some data
            int num1 = 1000;
            var dog = new Dog();
            dog.Age = 10;
            //pass into methods
            Console.WriteLine(num1);
            AddOne(num1);
            Console.WriteLine(num1);                //original UNCHANGED
            //what happens to original data?
            Console.WriteLine(dog.Age);
            AddOneYearToDogAge(dog);
            Console.WriteLine(dog.Age);             // original ALTERED


        }
        //pass in value type
        static void AddOne(int number)
        {
            number += 1;
        }

        //pass in reference (pointer)
        static void AddOneYearToDogAge(Dog d)
        {
            d.Age++;
        }
    }

    class Dog
        {
            public int Age { get; set; }

        }

}

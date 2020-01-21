using System;
using System.Collections.Generic;
using System.Dynamic;

namespace lab_08_literal_objects
{
    class Program
    {
        static void Main(string[] args)
        {
            //dont do this
            var string01 = new string("Here is a string");
            //do this
            var string02 = "here also is a string";

            //array : fixed in size (Immutable)
            //long way
            var array01 = new int[5]; //empty memory space to hold 5 integers
            var array02 = new int[] { 10, 20, 30, 40, 50 };   //literally defining the numbers

            var list01 = new List<int>();
            var list02 = new List<int>() { 10, 20, 30, 40, 50 };   //literals

            //random object
            dynamic object01 = new ExpandoObject();
            object01.name = "Fred";
            object01.age = 22;
            object01.balance = 32.50;
            Console.WriteLine($"object01 has name {object01.name} and age {object01.age}" + $"with balance {object01.balance}");

            // creating object as a literal
            var object02 = new
            {
                name = "Fred",
                age = 22
            };
            Console.WriteLine($"{object02.name} has age {object02.age}");

            //OOP language : create new object using literal data
            var dog01 = new Dog()
            {
                name = "Fido",
                age = 4
            };
            Console.WriteLine($"{dog01.name} is {dog01.age}");
        }
    }

    class Dog
    {
        public string name;
        public int age;
    }
}

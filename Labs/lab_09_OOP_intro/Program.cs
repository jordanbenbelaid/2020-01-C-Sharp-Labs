using System;

namespace lab_09_OOP_intro
{
    class Program
    {
        static void Main(string[] args)
        {
            //var keyword infers the type from the right ie Car
            //car01 is the instance ie particular object created
            //Car = template used
            //() means run a method when calling new keyword //constructor method
            var car01 = new Car();
            car01.Make = "Mercedes";

            for (int i = 0; i < 1000; i++)
            {
                //Create 1000 cars
                var car = new Car();
            }

            var newCar = new Car();
            Console.WriteLine($"Initial speed {newCar.Speed}");
            newCar.Speed++;
            newCar.Speed++;
            Console.WriteLine($"Final speed {newCar.Speed}");

            var car02 = new Car("Mercedes", "C220", "Silver", 2200);
        }
    }

    class Car
    {
        public string Make;
        public string Model;
        public string Colour;
        public int Length; //mm
        public int Speed;

        //constructor is present even if not stated
        //default constructor is
        public Car() 
        {
            this.Speed = 0;  // this keyword refers to Instance Object in use at the time        
        }

        public Car(string make, string model, string colour, int length)
        {
            this.Make = make;
            this.Model = model;
            this.Colour = colour;
            this.Length = length;
            this.Speed = 0;        

        }
    }
}

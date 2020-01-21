using System;

namespace lab_10_methods
{
    class Program
    {
        //MAIN METHOD!  Starts Program!
        static void Main(string[] args)
        {
            DoThis();
            DontDoThis();

            void DontDoThis()
            {
                Console.WriteLine("Dont do this");
            }

            var doggo = new Dog();
            doggo.Name = "Doggo";
            doggo.Grow();
            doggo.Grow();
            doggo.Grow();
            doggo.Grow();
            Console.WriteLine($"{doggo.Age} has {Dog.numLegs} legs");      //doggo age is the instance of the dog class 
                                                                            //(unique to doggo class)
                                                                           // Dog is the same for everyone in general
                                                                           //(static to the Dog class)
        }

        //static allows method to be called/run without creating the instance
        static void DoThis()
        {
            Console.WriteLine("I am doing this");
        }

    }

    class Dog
    {
        public string Name;
        public int Age;
        public static int numLegs = 4;

        public Dog()
        {
            this.Age = 0;
        }

        public void Grow()
        {
            this.Age++;
        }
    }
}

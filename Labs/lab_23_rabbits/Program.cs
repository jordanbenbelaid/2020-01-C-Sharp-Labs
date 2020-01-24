using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace lab_23_rabbits
{
    class Program
    {
        static void Main(string[] args)
        {

            //lab 1 
            //create 100 rabbits

            
            var rabbit = new List<Rabbit>();
            //give them all ID, name and age
            for (int i = 0; i < 100; i++)
            {
                var newRabbit = new Rabbit();
                rabbit.Add(newRabbit);
            }

            foreach (var item in rabbit)
            {
                Console.WriteLine($"This rabbit is called {item.RabbitName} and is {item.Age} years old, with ID : {item.RabbitId}");
            }

            //print a sample (every 10 items)

            //lab 2
            //create a loop to 'age' the rabbits
            for (int i = 0; i < 50; i++)
            {
                RabbitAge(rabbit);
            }

            void RabbitAge(List<Rabbit>r)
            {
                r.ForEach(item => item.Age++);
            }

            //print a sample
            foreach (var item in rabbit)
            {
                Console.WriteLine($"This rabbit is called {item.RabbitName} and is {item.Age} years old, with ID : {item.RabbitId}");
            }

            //breed rabbits so that each year, a rabbit breeds another rabbit

        }
    }

    class Rabbit
    {
        public int RabbitId { get; set; }
        public string RabbitName { get; set; }
        public int Age { get; set; }

        string[] namelist = new string[] { "james", "jamie", "karim", "hassan", "stephen", "phil", "colette", "ahmed", "tim", "asher" };
        Random random = new Random();

        public Rabbit()
        {
            Age = 0;
            RabbitId = random.Next(0, 1000);
            RabbitName = namelist[random.Next(0, namelist.Length - 1)];
        }
    }

}

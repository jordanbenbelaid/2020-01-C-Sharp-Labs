using System;

namespace lab_43_OOP_events
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Child("Fred");
            //c.Name = "Fred";
            c.Grow();
            c.Grow();
            c.Grow();
            c.Grow();
            c.Grow();
            Console.WriteLine($"{c.Name}'s age is now {c.Age}");

        }
    }

    class Child
    {
        //declare delegate and event here rather than program class
        delegate void BirthdayDelegate();
        event BirthdayDelegate BirthdayEvent;

        private string _name;
        //properties
        
            //Long way
        public string Name 
        { 
            get { return this._name; }
            set { this._name = value; }
        }

        //simple way
        public int Age { get; set; }

        //new child age is 0
        public Child(string name)
        {
            this._name = name;
            this.Age = 0;
            //initialise event by adding at least 1 method
            BirthdayEvent += HaveBirthdayParty;
        }

        public void Grow()
        {
            //trigger the event
            BirthdayEvent();
        }

        void HaveBirthdayParty()
        {
            Console.WriteLine("Child is having a new birthday");
            Age++;
        }
    }
}

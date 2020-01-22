using System;

namespace lab_14_abstract_class
{
    class Program
    {
        static void Main(string[] args)
        {
            //var abstractHoliday = new Holiday();    this does not work
            //abstract class : CODE MISSING
            var realHoliday = new ActuallyGo();
            realHoliday.BookHotel();
            realHoliday.GetMoney();
            realHoliday.GetThere();
            realHoliday.VisitNamibia();     // concrete class (ALL CODE COMPLETE)
        }
    }

    //Cannot create instances yet since code not complete
    abstract class Holiday
    {
        public abstract void GetThere();

        public abstract void BookHotel();

        public void VisitNamibia()
        {
            Console.WriteLine("We know where we want to visit!");
        }

        public void GetMoney()
        {
            Console.WriteLine("Yeah, we go the funds!");
        }                       //Code body/Implementation
    }

    //Concrete class because we can create new instances and actually go on holiday since everything is filled
    class ActuallyGo : Holiday
    {
        public override void GetThere()
        {
            Console.WriteLine("Fly then drive!");
        }

        public override void BookHotel()
        {
            Console.WriteLine("In the safari park!");
        }
    }
}

using System;

namespace lab_32_variables_final
{
    class Program
    {       
        //readonly in class
        readonly public double PI1 = 3.1415;
        //Property - Use get not set ///Set with the constructor but at no other time
        public DateTime DateOfBirth { get; }

        static void Main(string[] args)
        {
            //const doesnt allow you to change value after initiating it
            const double PII = 3.1415;

            var p = new Parent();
            // p.DateOfBirth = DateTime.Now;
            Console.WriteLine(p.DateOfBirth);

            //null
            var emptyString = "";               //box for data but nothing in the box
            string nullString = null;           //ponts to 'null' element
            Console.WriteLine($"Is an empty string null ?   {emptyString==nullString}");

            //null coalesce
            //replaces if .... its null ... do this ... else ... do this
            string databaseItem = null;
            string myItem = databaseItem ?? "invalid";
            Console.WriteLine(myItem);      //should give invalid item
            
            databaseItem = "real item";
            myItem = databaseItem ?? "invalid";
            Console.WriteLine(myItem);      //should give a real item

            databaseItem = null;
            //cant take length of null so will throw and exception
            //Console.WriteLine(databaseItem.Length);

            //null check
            Console.WriteLine(databaseItem?.Length);            //safely returns null

            //Casting and Boxing
            //Casting from one type to another
            //EXPLICIT CAST
            double num1 = 1.23;
            int integer1 = (int)num1;       //dangerous operation as it cuts/truncates data
            Console.WriteLine($"{num1} becomes {integer1}");

            //OK from int ot double 1 ==> 1.0 safely
            //IMPLICIT CAST
            int integer2 = 12;
            double num2 = integer2;

            //Boxing just casts to a general object
            var item1 = 12;
            var item2 = "hi";
            var object1 = (object)item1;
            var object2 = (object)item2;
            //Object is parent of all parents (top of computer hierarchy)
            int getMyItemBack = (int)object1;

            //nullable type
            //Integers, booleans and doubles cannot be null
            int num3 = default;         //0 not null
            //database number which is blank ==>0 ?  incorrect as its still a value
            int? databaseNumber = null;         //question mark lets us use null
            bool? databaseIsAlive = null;
            double? databasePrice = null;
        }
    }

    class Parent
    {
        public DateTime DateOfBirth { get; }
        public Parent()
        {
            this.DateOfBirth = DateTime.Today;
        }
    }
}

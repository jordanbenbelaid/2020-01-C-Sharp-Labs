using System;

namespace lab_12_properties
{
    class Program
    {
        static void Main(string[] args)
        {
            var user01 = new User("NT353637","AB");
            Console.WriteLine($"{user01.NINO}");
            user01.NINO = null; //resets it
            user01.Age = -100;                  // testing numbers outside of the values
            Console.WriteLine($"Age is now {user01.Age}");
        }

        class User
        {
            //Fields (private)
            private string _NINO;
            private string _bloodType;
            private int _age;

            //Constructor

            public User(string nino, string bloodtype)
            {
                this._NINO = nino;
                this._bloodType = bloodtype;
            }
            //short version of public property
            //public int Height { get; set; }

            // public property
            public string NINO
            {
                get { return this._NINO; }
                set { this._NINO = value; }     //value is built into c# as carrier of data from MAIN() to Instance
            }

            public int Age
            {
                get { return this._age; }
                set
                {
                    if (value >= 0)
                    {
                        this._age = value;
                    }
                    else
                    {
                        Console.WriteLine("Age cannot be negative");
                    }
                }
            }

            public string BloodType
            {
                get { return this._bloodType; }
                set { this._bloodType = value;  }
            }
        }
    }
}

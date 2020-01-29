using System;

namespace lab_35_overloading
{
    class Program
    {
        static void Main(string[] args)
        {
            var person1 = new Person();
            var person2 = new Person(10);
            var person3 = new Person("Tasha");
            person2.Age++;
        }
    }

    class Person
    {
        //default constructor, hidden, with new values
        private int _age = -1;
        private string Name { get; set; }
        public Person() { } //default
        
        //short version of age
        public Person (int age)
        {
            this._age = age;
        }
        
        //long version of age
        public int Age
        {
            get
            {
                return this._age;
            }
            set
            {
                this._age = value;
            }
        }
        public Person(string name)
        {
            this.Name = name;
        }
    }
}

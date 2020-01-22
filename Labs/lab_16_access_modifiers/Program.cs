using System;

namespace lab_16_access_modifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Parent();
            var c = new Child();
            var dog = new Dog();
            
            //p._hidden...

            p.Exposed = "Yes we can see this";
            c.Exposed = "Yes also visible";
            p.IsUserLive = true;
            c.IsUserLive = true;

            dog.Name = "Greatest Dog";
            p.TakeForWalk(dog);
            c.TakeForWalk(dog);
        }
    }

    class Dog
    {
        public string Name { get; set; }
      
    }
    class Parent
    {
        private int _hidden;            //encapsulation

        public string Exposed { get; set; }

        internal bool IsUserLive;           //visible in .EXE/DLL but not outside it

        protected string FamilyName;            //visible in child

        public void TakeForWalk(Dog d)
        {
            Console.WriteLine($"Taking {d.Name} for a walk");
        }
    }

    class Child : Parent
    {
        //Can't put code directly in the class
        //Use constructor but can use any method

        public Child()
        {
            this.FamilyName = "Robertson";
        }
    }
}

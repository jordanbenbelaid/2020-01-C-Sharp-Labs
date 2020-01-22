using System;

namespace lab_13_polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            Parent parent = new Parent();
            Child child = new Child();
            Child2 child2 = new Child2();

            parent.Jordan();
            child.Jordan();
            child2.Jordan();
        }
    }

    class Parent
    {
        public virtual void Jordan()
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Child : Parent
{
        public override void Jordan()
        {
            Console.WriteLine("Hello World and Jordan!");
        }

    }

    class Child2 : Parent
    {
        public override void Jordan()
        {
            Console.WriteLine("Hello Everyone!");
        }
    }
}

using System;

namespace lab_16_access_modifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Parent();
            var c = new Child();

            //p._hidden...

            p.Exposed = "Yes we can see this";
            c.Exposed = "Yes also visible";
        }
    }

    class Parent
    {
        private int _hidden;            //encapsulation

        public string Exposed { get; set; }

        internal bool IsUserLive;           //visible in .EXE/DLL but not outside it

        protected string FamilyName;            //visible in child
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_25_test_database
{
    class Program
    {
        static void Main(string[] args)
        {
            //2 things
            //
            //1 wrap database call in 'using' statement
            //using ==> clean up code aftewrwards even if system failure
            //2 create new instance of database

            List<testtable> itemList = new List<testtable>();

            using (var db = new testdatabaseEntities())
            {
                //List of items = call the database, 
                //Extract testtable data
                //Convert output to a list type
                itemList = db.testtables.ToList();
            }
            // foreach...print items
            foreach (var item in itemList)
            {
                Console.WriteLine($"{item.TestName,-15} has an ID of {item.TestTableId,-10} " +
                    $"and is {item.TestAge} years old");
            }
        }
    }
}

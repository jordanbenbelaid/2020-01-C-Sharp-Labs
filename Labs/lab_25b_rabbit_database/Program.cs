using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_25b_rabbit_database
{
    class Program
    {
        static void Main(string[] args)
        {
            List<RabbitTable> rabbitList = new List<RabbitTable>();

            using (var db = new RabbitDatabaseEntities())
            {
                rabbitList = db.RabbitTables.ToList();
            }

            var rabbit = new RabbitTable()
            {
                RabbitName = "NewRabbit", 
                RabbitAge = 4    
            };

            using (var db = new RabbitDatabaseEntities())
            {
              db.RabbitTables.Add(rabbit);
              db.SaveChanges();
              rabbitList = db.RabbitTables.ToList();
            }

            foreach (var item in rabbitList)
            {
                Console.WriteLine($"{item.RabbitName,-15} has an ID of {item.RabbitTableId,-10} " +
                    $"and is {item.RabbitAge} years old");
            }


        }
    }
}

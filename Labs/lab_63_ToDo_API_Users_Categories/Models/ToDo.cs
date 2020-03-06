using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_63_ToDo_API_Users_Categories.Models
{
    public class ToDo
    {
        public int ToDoID { get; set; }
        public string ToDoName { get; set; }

        //Foreign key
        public User User { get; set; }
        public int? UserID { get; set; }
        
    }
}

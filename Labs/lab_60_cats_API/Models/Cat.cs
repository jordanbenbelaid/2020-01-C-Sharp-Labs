using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab_60_cats_API.Models
{
    public class Cat
    {
        public int CatID { get; set; }
        public string CatName { get; set; }

        //foreign key : Each cat has a category
        public int? CategoryID { get; set; }
        public Category Category { get; set; }
        
        [Display(Name = "Dat Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

    }
}

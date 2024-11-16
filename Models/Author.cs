using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Pop_Lucas_Lab2.Models;

namespace Nume_Pren_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; } 

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}

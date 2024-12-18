using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Pop_Lucas_Lab2.Models
{
    public class Member
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Adress { get; set; }
        public string Email { get; set; }

        [RegularExpression(@"^0([0-9]{3})[-. ]?([0-9]{3})[-. ]?([0-9]{3})$",
        ErrorMessage = "Telefonul trebuie să înceapă cu 0 și să fie de forma '0722-123-123', '0722.123.123' sau '0722 123 123'.")]
        public string? Phone { get; set; }


        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public ICollection<Borrowing>? Borrowings { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPagesDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Is Required")]
        [MinLength(3, ErrorMessage = "Name should contain at least 3 characters.")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Invalid Email Format")]
        
        [Display(Name="Custom Email")]
        public string Email { get; set; }
        public string PhotoPath { get; set; }

        [Required]
        public Dept? Department { get; set; }
    }
}

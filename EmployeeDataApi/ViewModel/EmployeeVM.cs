using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDataApi.ViewModel
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Firstname")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Firstname")]
        public string Email { get; set; }

        [Display(Name = "PhoneNumber")]
        [DataType(DataType.PhoneNumber)]
        public decimal? Phone { get; set; }


        [Required(ErrorMessage = "Please enter Joining_Date")]
        public DateTime? hire_date { get; set; }


        [Required(ErrorMessage = "Please enter Position")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter Description")]
        public string Description { get; set; }


   
    }
}

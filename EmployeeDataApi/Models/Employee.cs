using System;
using System.Collections.Generic;

namespace EmployeeDataApi.Models
{
    public partial class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal? Phone { get; set; }
        public string Position { get; set; }
        public string Password { get; set; }
        public DateTime? HireDate { get; set; }
        public string Description { get; set; }
    }
}

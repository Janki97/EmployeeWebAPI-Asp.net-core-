using System;
using System.Collections.Generic;

namespace EmployeeDataApi.Models
{
    public partial class Employees
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Position { get; set; }
        public string OfficeLocation { get; set; }
    }
}

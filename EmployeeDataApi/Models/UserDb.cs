using System;
using System.Collections.Generic;

namespace EmployeeDataApi.Models
{
    public partial class UserDb
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
    }
}

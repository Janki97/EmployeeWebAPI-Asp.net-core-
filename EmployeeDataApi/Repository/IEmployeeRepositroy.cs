
using EmployeeDataApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDataApi.Repository
{
   public interface IEmployeeRepositroy
    {

        int Authenticate(EmployeeVM lg);
        EmployeeVM GetEmployee(int? Id);
        List<EmployeeVM> GetAllEmployees();

        int AddEmployee(EmployeeVM employee);

       // int employeelogin(string employee, string lg);
        void UpdateEmployee(EmployeeVM post);
        void DeleteEmployee(int? emp_id);
    }
}

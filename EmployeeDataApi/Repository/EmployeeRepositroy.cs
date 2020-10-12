

using EmployeeDataApi.ViewModel;
using EmployeeDataApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDataApi.Repository
{
    public class EmployeeRepositroy : IEmployeeRepositroy
    {

        DemoDBContext db;
        public EmployeeRepositroy(DemoDBContext _db)
        {
            db = _db;
        }

        public int AddEmployee(EmployeeVM e)
        {
            if (db != null)
            {
                var employee = new Employee
                {
                    EmpId = e.Id,
                    Name = e.Name,
                    Email = e.Email,
                    Phone = e.Phone,
                    Position=e.Position,
                    Password =e.Password,
                    HireDate=e.hire_date,
                    Description=e.Description
                };
                db.Employee.Add(employee);
                db.SaveChanges();

                return employee.EmpId;
            }
            return 0;
        }

       public int Authenticate(Employee e)
        {
            var employee = new Employee
            {
               
                Email = e.Email,
                Password = e.Password,
            };

            return 0;
        }

        public int Authenticate(EmployeeVM e)
        {
            var employee = new Employee
            {

                Email = e.Email,
                Password = e.Password,
            };

            return 0;
        }

        public void DeleteEmployee(int? emp_id)
        {
            if (db != null)
            {
                var emp = (from e in db.Employee where e.EmpId == emp_id select e).FirstOrDefault();
                db.Employee.Remove(emp);
                db.SaveChanges();
            }
        }

      

        public List<EmployeeVM> GetAllEmployees()
        {
            if (db != null)
            {
                return (from e in db.Employee
                        select new EmployeeVM
                        {
                            Id = e.EmpId,
                            Name = e.Name,
                            Email = e.Email,
                            Phone = e.Phone,               
                            Position = e.Position,
                            hire_date = e.HireDate,
                            Description = e.Description

                        }).ToList();
            }
            return null;
        }

        public EmployeeVM GetEmployee(int? Id)
        {
            

            if(db != null)
            {
                return (from e in db.Employee
                        where e.EmpId == Id
                        select new EmployeeVM
                        {
                            Id = e.EmpId,
                            Name = e.Name,
                            Email = e.Email,
                            Phone = e.Phone,
                            Position = e.Position,
                            hire_date = e.HireDate,
                            Description = e.Description,
                            Password = e.Password
                        }).FirstOrDefault();
            }
            return null;
        }

        public void UpdateEmployee(EmployeeVM e)
        {
            if (db != null)
            {
                var employee = new Employee
                {
                    EmpId = e.Id,
                    Name = e.Name,
                    Email = e.Email,
                    Phone = e.Phone,
                    Position = e.Position,
                    HireDate = e.hire_date,
                    Description = e.Description,
                    Password = e.Password
                };
                db.Employee.Update(employee);
                db.SaveChanges();
            }
        }
    }
}

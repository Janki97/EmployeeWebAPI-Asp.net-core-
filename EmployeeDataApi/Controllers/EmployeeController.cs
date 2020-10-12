using System;
using System.Threading.Tasks;
using EmployeeDataApi.Repository;
using EmployeeDataApi.ViewModel;
using EmployeeDataApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeDataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        IEmployeeRepositroy employeeRepositroy;

        public EmployeeController(IEmployeeRepositroy _employeeRepositroy)
        {
            employeeRepositroy = _employeeRepositroy;
        }


        [HttpGet]
        //[Route("Employees")]
        public IActionResult GetAllUser()
        {
            try
            {
                var emp = employeeRepositroy.GetAllEmployees();
                if (emp == null)
                {
                    return NotFound();
                }
                return Ok(emp);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Employees/{id}")]

        public IActionResult GetUser(int Id)
        {
            try
            {
                var emp = employeeRepositroy.GetEmployee(Id);
                if (emp == null)
                {
                    return NotFound();
                }
                return Ok(emp);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("Employee")]
        public IActionResult AddUser([FromBody] EmployeeVM model)
        {

            try
            {
                var empID = employeeRepositroy.AddEmployee(model);
                if (empID > 0)
                {
                    return StatusCode(StatusCodes.Status201Created, "Employee Created Successfully with ID :" + empID);

                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Route("/Login")]
        [HttpPost]
        public IActionResult Authenticate(EmployeeVM lg)
        {

            try
            {
                var empID = employeeRepositroy.Authenticate(lg);
                if (empID > 0)
                {
                    return StatusCode(StatusCodes.Status201Created, "Employee Created Successfully with ID :" + empID);

                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [Route("Employee/{id}")]
        public IActionResult UpdateEmployee([FromBody] EmployeeVM model, int id)
        {
            try
            {
                if (id > 0)
                {
                    var emp = employeeRepositroy.GetEmployee(id);
                    if (emp == null)
                    {
                        return NotFound();
                    }
                    emp.Id = id;
                    emp.Name = model.Name;
                    emp.Email = model.Email;
                    emp.Phone = model.Phone;        
                    emp.Position = model.Position;      
                    emp.hire_date = model.hire_date;
                    emp.Description = model.Description;
                    emp.Password = model.Password;
                    employeeRepositroy.UpdateEmployee(emp);
                    return Ok("User Updated Successfully");

                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("Employee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                if (id > 0)
                {
                    var user = employeeRepositroy.GetEmployee(id);
                    if (user == null)
                    {
                        return NotFound();
                    }
                    employeeRepositroy.DeleteEmployee(id);
                    return Ok("employee Deleted Successfully");

                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

       
    }
}

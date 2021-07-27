using EmployeesWebAPI.DAL;
using EmployeesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace EmployeesWebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: Employee
        public IHttpActionResult Get()
        {
            List<Employee> employees = new List<Employee>();
            EmployeeDAL empDal = new EmployeeDAL();
            employees = empDal.GetEmployees();
            return Json(employees);
        }


        public IHttpActionResult Get(string FirstName)
        {
            List<Employee> employees = new List<Employee>();
            EmployeeDAL empDal = new EmployeeDAL();
            employees = empDal.GetEmployeesByParams(FirstName);
            return Json(employees);
        }

        [HttpPost]
        public IHttpActionResult Post(Employee emp)
        {
            List<Employee> employees = new List<Employee>();
            EmployeeDAL empDal = new EmployeeDAL();
            int result = empDal.AddNewEmployee(emp);
            if (result == 1 )
            {
                employees.Add(emp);
                return Json(employees);
            }          
            return Get();
        }
    }
}
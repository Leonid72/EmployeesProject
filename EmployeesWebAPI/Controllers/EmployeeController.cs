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
    }
}
using EmployeesWebAPI.DAL;
using EmployeesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        public IHttpActionResult Get(int id)
        {
            Employee emp = new Employee();
            EmployeeDAL empDal = new EmployeeDAL();
			if (id > 0 )
			{
                emp = empDal.GetEmployeeByID(id);
            }
			else
			{
                //Write to log not valid ID
			}

            return Json(emp);
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
            //if (result == 1 )
            //{
            //    employees.Add(emp);
            //    return Json(employees);
            //}
            employees = empDal.GetEmployees();
            return Json(employees);
        }

        [HttpPut]
        //public IHttpActionResult Put(Employee emp)
        public HttpResponseMessage Put(Employee emp)
        {
            List<Employee> employees = new List<Employee>();
            EmployeeDAL empDal = new EmployeeDAL();
            int rows = empDal.UpdateEmployee(emp);

            if (rows > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotModified, "NotModified");
            }
            //if (result == 1 )
            //{
            //    employees.Add(emp);
            //    return Json(employees);
            //}
            //employees = empDal.GetEmployees();
            //return Json(employees);
        }
    }
}
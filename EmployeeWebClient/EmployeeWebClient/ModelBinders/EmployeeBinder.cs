using EmployeeWebClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeWebClient.ModelBinders
{
    public class EmployeeBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpContextBase objContext = controllerContext.HttpContext;
            string empFirstName = objContext.Request.Form["employee.FirstName"];
            string empLastName = objContext.Request.Form["employee.LastName"];

            Employee emp = new Employee();
            emp.FirstName = empFirstName;
            emp.LastName = empLastName;
            return emp;
        }
    }
}
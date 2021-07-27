
using EmployeeWebClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeWebClient.ViewModels
{
    public class EmployeeVM
    {
        public Employee employee { get; set; }
        public List<Employee>  employees { get; set; }
    }
}
using EmployeeWebClient.Models;
using EmployeeWebClient.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using EmployeeWebClient.ModelBinders;
namespace EmployeeWebClient.Controllers
{
    public class TestController : Controller
    {
        Uri uriAddress = new Uri("https://localhost:44328/api");
        HttpClient httpClient;
        EmployeeVM empVM;


        public TestController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = uriAddress;
            empVM = new EmployeeVM();
        }

        [HttpGet]
        public ActionResult Test()
        {
            List<Employee> employees = new List<Employee>();
            HttpResponseMessage httpResponse = httpClient.GetAsync(httpClient.BaseAddress + "/Employee").Result;
            if (httpResponse.IsSuccessStatusCode)
            {
                var data = httpResponse.Content.ReadAsStringAsync().Result;
                empVM.employees = JsonConvert.DeserializeObject<List<Employee>>(data);
            }
            return View("Test", empVM);
        }


        [HttpPost]
        public ActionResult AddEmployee([ModelBinder(typeof(ModelBinders.EmployeeBinder))] Employee emp)
        {
            return View("Test", empVM);
        }
    }
}

using EmployeeWebClient.Models;
using EmployeeWebClient.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EmployeeWebClient.Controllers
{
    public class EmployeeController : Controller
    {
        Uri uriAddress = new Uri("https://localhost:44328/api");
        HttpClient httpClient;
        EmployeeVM empVM;


        public EmployeeController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = uriAddress;          
            empVM = new EmployeeVM();
        }


        // GET: Employee
        [HttpGet]
        public ActionResult Employees()
        {
            List<Employee> employees = new List<Employee>();
            HttpResponseMessage httpResponse = httpClient.GetAsync(httpClient.BaseAddress + "/Employee").Result;
            if (httpResponse.IsSuccessStatusCode)
            {
                var data = httpResponse.Content.ReadAsStringAsync().Result;
                empVM.employees = JsonConvert.DeserializeObject<List<Employee>>(data);
            }
            return View("Employees",empVM);
        }



        [HttpGet]
        public ActionResult SearchEmployee(string txtFirstName, string txtLastName) ///string txtFirstName,string txtLastName
        {
            string filter = "";
            if (!String.IsNullOrEmpty(txtFirstName))
            {
                filter += $"?FirstName={txtFirstName}";
            }

            List<Employee> employees = new List<Employee>();
            HttpResponseMessage httpResponse = httpClient.GetAsync(httpClient.BaseAddress + "/Employee" + filter).Result;
            if (httpResponse.IsSuccessStatusCode)
            {
                var data = httpResponse.Content.ReadAsStringAsync().Result;
                empVM.employees = JsonConvert.DeserializeObject<List<Employee>>(data);
            }
            return View("Employees", empVM);
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

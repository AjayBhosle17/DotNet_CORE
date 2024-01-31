using _03_State_Management_Controller_To_View.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace _03_State_Management_Controller_To_View.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {

            ViewData["Name"] = "Ajay  Bhosle";
            ViewBag.Age = 20;

            TempData["Title"] = "Talk Is cheap show me the code...!";

            Customer obj = new Customer() { Name="Ajay",Age=22,Email="Ajaybhosle.comp@gmail.com"};

            TempData["customerData"] = obj;

            

            // Session

            HttpContext.Session.SetString("Name", "Ajay Bhosle");    // setdata
            


            // can not set complex type data in session

            Customer customer = new Customer()
            {
                Name="Ajay Bhosle",
                Email="Ajaybhosle.comp@gmail.com",
                Age=16
            };

           // HttpContext.Session.SetString("CustomersData", customer);  // this type way not work


            string c = JsonSerializer.Serialize(customer);
            HttpContext.Session.SetString("CustomerData", c);

            return View();

        }

        public IActionResult Create()
        {
            return View();
        }


    }
}

using _03_State_Management_Controller_To_View.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace _03_State_Management_Controller_To_View.Controllers
{
    public class CategoryController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details( string? Name, string? Email , int? Age)
        {
            ViewBag.Name = Name;
            ViewBag.Email = Email;
            ViewBag.Age = Age;

            // set data in cookie and set time also

            Response.Cookies.Append("Name", Name);
            Response.Cookies.Append("Email", Email, new CookieOptions()
            {
                Expires = DateTime.Now.AddSeconds(10)
            });

            Response.Cookies.Append("Age", Age.ToString());

            Customer c = new Customer() { Name=Name , Email=Email , Age=Age??0};

            //Response.Cookies.Append("customers", c); not suppoort complex type

            string customer = JsonSerializer.Serialize(c);
            Response.Cookies.Append("customer", customer);

            return View();
        }

        [HttpGet]

        public IActionResult Edit()
        {
           ViewBag.Name = Request.Cookies["Name"];
           ViewBag.Email = Request.Cookies["Email"];

           ViewBag.Age = Request.Cookies["Age"];

            var customer = Request.Cookies["customer"];
            Customer c = JsonSerializer.Deserialize<Customer>(customer);

            ViewBag.Customer = c;
            return View();
        }
    }
}

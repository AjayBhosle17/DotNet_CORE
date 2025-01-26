using _01_MVC_Core_Introduction.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01_MVC_Core_Introduction.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details()
            
        {
            Category c = new Category() { Id = 1, Name = "MEns Wear", Rating = 4 };

            return View(c);
        }
    }
}

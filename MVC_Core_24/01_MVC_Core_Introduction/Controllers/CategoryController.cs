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
            //return View();
            return View("CreateNew");
        }

        [HttpGet]
        public IActionResult Details()
            
        {
            Category c = new Category() { Id = 1, Name = "MEns Wear", Rating = 4 };

            return View(c);
        }


        /*[HttpGet]
        // is not way of Dynamic Partial View in core
        public PartialViewResult DyanamicPartialView()
        {
            Category c = new Category()
            {
                Id=1 , 
                Name="Mens Wear",
                Rating=4
            };
            //return PartialView(c);
            return PartialView("_PartialView2",c);
        }*/

    }
}


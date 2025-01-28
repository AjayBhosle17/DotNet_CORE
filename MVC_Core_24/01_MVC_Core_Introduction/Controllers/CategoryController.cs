using _01_MVC_Core_Introduction.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01_MVC_Core_Introduction.Controllers
{

    [Route("Category")]
    [Route("")]
    public class CategoryController : Controller
    {
        [Route("")] // Matches "Category" or "Category/Index"
        [Route("Index")] // Matches "Category/Index"
        public IActionResult Index()
        {
            return View();
        }

        [Route("Create")] // Matches "Category/Create"
        public IActionResult Create()
        {
            //return View();
            return View("CreateNew");
        }

        [HttpGet]
        [Route("Details")] // Matches "Category/Details"
        public IActionResult Details()
        {
            Category c = new Category() { Id = 1, Name = "Mens Wear", Rating = 4 };

            return View(c);
        }

        [HttpGet]
        [Route("DetailsByName/{name}")] // Matches "Category/DetailsByName/{name}"
        [Route("Ab/{name}")]
        public IActionResult DetailsByName(string name)
        {
            return View("DetailsByName", name);
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


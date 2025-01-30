using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace _02_ViewToController.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(int? id, string name)
        {
            ViewBag.Id = id;
            ViewBag.Name = name;
            return View();
        }

        [HttpPost]

        public IActionResult Create(string Name , int? price )  // simple type as parameter
        {
            string name = Name;
            int Price = price ?? 0;
            return View();
        }

        [HttpGet]
        public IActionResult Details()
        {
           
            return View();
        }
    }
}

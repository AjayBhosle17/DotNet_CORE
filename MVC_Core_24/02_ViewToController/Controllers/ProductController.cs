using _02_ViewToController.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace _02_ViewToController.Controllers
{
    public class ProductController : Controller
    {

        IWebHostEnvironment _host;

        public ProductController(IWebHostEnvironment host)
        {
            _host = host;
        }

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

        /* public IActionResult Create(string Name, int? price)  // simple type as parameter

         {
             string name = Name;
             int Price = price ?? 0;
             return View();
         }*/

        /*   public IActionResult Create(IFormCollection form) // Using IFormCollection as a Para
           {
               string Name = form["Name"];
               int price = int.Parse(form["Price"]);
               string discount = form["Discount"];
               return View();
           }*/

     //   public IActionResult Create(Product product) {  // model as Parameter 
        
        public IActionResult Create([Bind("Name","Price","formFile")] Product product) {
            string Name = product.Name;
            int Price = product.Price;
            string Discount = product.Discount;
            IFormFile file = product.formFile;

            string fileName = file.FileName;
            string fileType = file.ContentType;

            // upload file

            string rootfolder = _host.WebRootPath;
            string filepath = Path.Combine(rootfolder,"images" ,fileName);

            using(var stream = new FileStream(filepath, FileMode.Create))
            {
                product.formFile.CopyTo(stream);
            }


            return View(product);
        }

        [HttpGet]
        public IActionResult Details()
        {
           
            return View();
        }
    }
}

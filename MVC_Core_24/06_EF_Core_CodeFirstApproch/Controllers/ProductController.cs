using _06_EF_Core_CodeFirstApproch.Models;
using _06_EF_Core_CodeFirstApproch.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace _06_EF_Core_CodeFirstApproch.Controllers
{
    public class ProductController : Controller
    {
        CoreDbContext _context;

        public ProductController(CoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(int? categoryId)
        {
            var products = new List<Product>();
            if (categoryId == null)
            {
                products=_context.Products.ToList();
            }
            else
            {
                products = _context.Products.Where(p=>p.CategoryId == categoryId).ToList();
            }
            
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
     


        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {

                return View();
            }

            var product = _context.Products.Find(id);


            if (product == null)
            {

                return NotFound();
            }
            return View(product);
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {

            if (id == null)
            {

                return View("Edit");
            }
            var product = _context.Products.Find(id);
            if (product == null)
            {

                return NotFound();
            }
            return View(product);

        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (product == null)
            {

                return View("Edit");
            }
            var product1 = _context.Products.Find(product.Id);

            if (product1 == null)
            {

                return NotFound();
            }

            product1.Name = product.Name;
            product1.Stock = product.Stock;
            product1.Price = product.Price;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {

            if (id == null)
            {

                return View("Delete");
            }

            var product = _context.Products.Find(id);
            if (product == null)
            {

                return NotFound();
            }

            return View(product);

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {

                return View("Delete");
            }

            var product = _context.Products.Find(id);

            if (product == null)
            {

                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}

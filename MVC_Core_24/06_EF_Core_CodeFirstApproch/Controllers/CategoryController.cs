using _06_EF_Core_CodeFirstApproch.Models;
using _06_EF_Core_CodeFirstApproch.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace _06_EF_Core_CodeFirstApproch.Controllers
{
    public class CategoryController : Controller
    {
        CoreDbContext _context;

        public CategoryController(CoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = _context.Categories;
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        { 
        
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category == null) { 
            
                return View("Create");
            }
            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null) {

                return View();
            }

            var category = _context.Categories.Find(id);

            
            if (category == null) {

                return NotFound();
            }
            return View(category);
        }


        [HttpGet]
        public IActionResult Edit(int? id) {

            if (id == null) { 
            
                return View("Edit");
            }
            var category = _context.Categories.Find(id);
            if (category == null) { 
            
                return NotFound();
            }
            return View(category);

        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (category == null)
            {

                return View("Edit");
            }
            var category1 = _context.Categories.Find(category.Id);

            if (category1 == null)
            {

                return NotFound();
            }

            category1.Name = category.Name;
            category1.Order = category.Order;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int? id) {

            if (id == null) { 
            
                return View("Delete");
            }

            var category = _context.Categories.Find(id);
            if (category == null) { 
            
                return NotFound();
            }

            return View(category);
            
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null) { 
            
                return View("Delete");
            }

            var category = _context.Categories.Find(id);

            if (category == null) { 
            
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

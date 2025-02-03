using _05_EFCoreDBFirstApproch.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace _05_EFCoreDBFirstApproch.Controllers
{
    public class CategoryController : Controller
    {
        CategoryDBContext _context;

        public CategoryController(CategoryDBContext context)
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

        public IActionResult Details(int? id)
        {
            var category = _context.Categories.Find(id);

            return View(category);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category) {

            if (category != null)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();

                return RedirectToAction("Index");

            }
            else
            {

                return View(category);
            }
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {

            if (id != null)
            {

                var category=_context.Categories.Find(id);

                return View(category);
            }
            else
            {
                return View("Edit");
            }
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (category == null)
            {
                return View("Edit");
            }

            var existingCategory = _context.Categories.Find(category.Id);

            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.Name = category.Name;
            existingCategory.Rating = category.Rating;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int? id) {

            if (id == null) {

                return View("Delete");

            }
            var category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }


            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id) {

            if (id == null) { 
            
                return View("Delete");
            }
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}

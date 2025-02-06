using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Web_UI.Controllers
{
    public class PostController : Controller
    {
        IBlogPostService _service;

        public PostController(IBlogPostService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var postmodel = _service.GetAll();
            return View(postmodel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PostModel model)
        {
            _service.Create(model);
            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult Edit(int? id) { 
        
            var model = _service.GetById(id);
            if (model != null)
            {

                return View(model);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(PostModel model) {

            _service.Edit(model);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int? id) { 
        
            var post = _service.GetById(id);
            if (post != null) { 
            
                return View(post);
            }
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id) {

            if (id == null)
            {
                return NotFound();
            }
            var postmodel = _service.GetById(id);
            if (postmodel == null)
            {
                return NotFound();
            }

            _service.Delete(id); 
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult ViewPost(int id) {

            var post = _service.GetById(id);
            if (post != null) { 
            
                return View(post);
            }
            return View(); 

        }
    }
}

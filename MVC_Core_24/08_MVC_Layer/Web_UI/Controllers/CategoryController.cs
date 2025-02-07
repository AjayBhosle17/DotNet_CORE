using AutoMapper;
using CORE;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Web_UI.Models;

namespace Web_UI.Controllers
{
    /*[Authorize]*/
    /*[Authorize(Roles ="admin")]*/
    /*[Authorize(Policy ="AdminOnly")]*/

    [Authorize]
    public class CategoryController : Controller
    {
        ICategoryService _service;

       

        public CategoryController(ICategoryService service)
        {
            _service = service;
           
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = _service.GetAll();
            return View(categories);
        }

        [HttpGet]
        [Authorize(Policy="AdminOnly")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(CategoryModel model) {

            if (model == null) {

                return View(model);
            }

            _service.Create(model);

            return RedirectToAction("Index");
           
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var category = _service.Details(id);


            return View(category);

            
        }

        
    }
}

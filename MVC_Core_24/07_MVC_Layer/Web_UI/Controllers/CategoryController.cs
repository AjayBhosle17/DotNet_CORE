using AutoMapper;
using CORE;
using Microsoft.AspNetCore.Mvc;
using Services;
using Web_UI.Models;

namespace Web_UI.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _service;

        // use here automapper for category to categoryModel for show data

        IMapper _mapper;

        public CategoryController(ICategoryService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = _service.GetAll();
            var categoryModel = _mapper.Map<List<CategoryModel>>(categories);    // category to CategoryModel
            return View(categoryModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(CategoryModel model) {

            if (model == null) {

                return View(model);
            }

            var category = _mapper.Map<Category>(model);

            _service.Create(category);

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

            var categoryModel = _mapper.Map<CategoryModel>(category);

            return View(categoryModel);

            
        }

        
    }
}

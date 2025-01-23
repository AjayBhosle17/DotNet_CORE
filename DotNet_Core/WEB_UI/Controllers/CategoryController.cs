using BAL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB_UI.Controllers
{
    public class CategoryController : Controller
    {

        ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        // GET: Category
        public ActionResult Index()
        {
            var categories = _service.GetAll();
            return View(categories);
        }


        [HttpGet]
        public ActionResult Create()
        {

            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _service.Create(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id > 0)
            {
                Category category = _service.GetById(id);

                if (category != null)
                {
                    return View(category);
                }

                return HttpNotFound();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id > 0)
            {
                var category = _service.GetById(id);

                if (category != null)
                {
                    return View(category);
                }

                return HttpNotFound();
            }

            return RedirectToAction("Index");
        }

        
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _service.Edit(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id > 0)
            {
                var category = _service.GetById(id);

                if (category != null)
                {
                    return View(category);
                }

                return HttpNotFound();
            }

            return RedirectToAction("Index");
        }



        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _service.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}

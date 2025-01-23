using BAL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace WEB_UI.Controllers
{
    public class ProductController : Controller
    {

        IProductService _productService;

        public ProductController(IProductService service)
        {
            _productService = service;
        }

        // GET: Product
        public ActionResult Index()
        {
            var products = _productService.GetAll();
            return View(products);
        }

        [HttpGet]
        public ActionResult Create() { 
        
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product) {

            if (ModelState.IsValid)
            {
                _productService.Create(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpGet]

        public ActionResult Details(int? id) {

            if (id > 0)
            {
                Product product = _productService.GetById(id);

                if (product != null)
                {
                    return View(product);
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
                var product = _productService.GetById(id);

                if (product != null)
                {
                    return View(product);
                }

                return HttpNotFound();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Edit(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id > 0)
            {
                var product = _productService.GetById(id);

                if (product != null)
                {
                    return View(product);
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
                _productService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }

    }
}
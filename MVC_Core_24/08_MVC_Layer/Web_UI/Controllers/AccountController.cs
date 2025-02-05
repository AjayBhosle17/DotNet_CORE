using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using Web_UI.Models;

namespace Web_UI.Controllers
{
    public class AccountController : Controller
    {
        IUserService _service;

        public AccountController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                _service.CreateUser(model);

                return RedirectToAction("Login");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel userModel = _service.Login(model.Email, model.Password);

                if (userModel != null)
                {
                    return RedirectToAction("Success");
                }
 
            }
            return View();
        }

        [HttpGet]
        public IActionResult Success() { 
        
            return View();

        }

        [HttpGet]

        public IActionResult Logout()
        {

            return View();
        }

        
    }
}

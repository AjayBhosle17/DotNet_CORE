using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Security.Claims;
using Web_UI.Models;

namespace Web_UI.Controllers
{
    [AllowAnonymous]
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
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel userModel = _service.Login(model.Email,
                    model.Password);

                if (userModel != null)
                {
                    // user is registered and authenticated

                    var claims = new List<Claim>()
                    {
                            new Claim(ClaimTypes.Name, userModel.Email),
                            new Claim(ClaimTypes.Role, userModel.RoleName)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "MyAppAuthenticationScheme");

                    await HttpContext.SignInAsync("MyAppAuthenticationScheme",
                          new ClaimsPrincipal(claimsIdentity)); // user identity gets stored in cookie

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid email and or password");
            return View(model);
        }


        [HttpGet]
        public IActionResult Success() { 
        
            return View();

        }

        [HttpGet]

        public  async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MyAppAuthenticationScheme");
            return RedirectToAction("Login");
        }


        [HttpGet]
        public IActionResult AccessDenied() { 
        
            return View();
        }

     
        public IActionResult Profile()
        {
            var user = new UserModel
            {

                FirstName = User.Claims.FirstOrDefault(c => c.Type == "FirstName")?.Value,
                LastName = User.Claims.FirstOrDefault(c => c.Type == "LastName")?.Value,
                Email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
                ConfirmEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
                RoleName = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value,
                FacebookUrl = User.Claims.FirstOrDefault(c => c.Type == "FacebookUrl")?.Value,
                Age = User.Claims.FirstOrDefault(c => c.Type == "Age") != null ? int.Parse(User.Claims.FirstOrDefault(c => c.Type == "Age").Value) : (int?)null,
                DateOfBirth = User.Claims.FirstOrDefault(c => c.Type == "DateOfBirth") != null ? DateTime.Parse(User.Claims.FirstOrDefault(c => c.Type == "DateOfBirth").Value) : (DateTime?)null

            };

            return View(user);
        }
    }
}

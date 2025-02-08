using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Web_UI.Controllers
{
    [AllowAnonymous]
    public class TestController : Controller
    {
        TestService _service1;
        TestService _service2;
        TestService _service3;


        public TestController(TestService service1 , TestService service2 ,TestService service3)
        {
            _service1 = service1;
            _service2 = service2;
            _service3 = service3;

        }

        public IActionResult Index()
        {
            ViewBag.Instance1 = _service1.SameInstance();
            ViewBag.Instance2 = _service2.SameInstance();
            ViewBag.Instance3 = _service3.SameInstance();

            return View();

        }
        
    }
}

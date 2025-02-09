using Microsoft.AspNetCore.Mvc;

namespace _10_Logging_Serilog_Framework.Controllers
{
    public class LogController : Controller
    {
        ILogger<LogController> _logger;

        public LogController(ILogger<LogController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Log Messge 1");
            _logger.LogWarning("Log Message 2");
            _logger.LogError("Log Message 3");
            return View();
        }
    }
}

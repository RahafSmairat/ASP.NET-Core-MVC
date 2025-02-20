using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Study20.Models;

namespace Study20.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string num1, string num2, string operation)
        {
            if (operation == "sum")
            {
                TempData["Result"] = Convert.ToInt32(num1) + Convert.ToInt32(num2);
            }
            else if (operation == "dec")
            {
                TempData["Result"] = Convert.ToInt32(num1) - Convert.ToInt32(num2);
            }
            else if (operation == "multiply")
            {
                TempData["Result"] = Convert.ToInt32(num1) * Convert.ToInt32(num2);
            }
            else if (operation == "divi")
            {
                TempData["Result"] = Convert.ToInt32(num1) / Convert.ToInt32(num2);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

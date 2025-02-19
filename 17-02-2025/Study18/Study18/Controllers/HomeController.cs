using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Study18.Models;

namespace Study18.Controllers
{
    //public class User
    //{
    //    public string Name { get; set; }
    //    public string Email { get; set; }
    //}
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var stringArray = new string[3] { "Manual", "Semi", "Auto" };
            ViewBag.Collection = new string[3] { "Manual", "Semi", "Auto" }; ;
            return View();
        }

        public IActionResult Privacy()
        {
            //ViewBag.Names = new List<string> { "Sara", "Rahaf" };
            return View();
        }

        //[HttpPost]
        //public IActionResult SaveUser([FromBody] User user)
        //{
        //    if (user == null)
        //    {
        //        return Content("No data received");
        //    }

        //    return Content($"User: {user.Name}, Email: {user.Email}");
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Task1.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }
    }
}

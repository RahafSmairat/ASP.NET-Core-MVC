using Microsoft.AspNetCore.Mvc;

namespace Task1.Controllers
{
    public class AboutController1 : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}

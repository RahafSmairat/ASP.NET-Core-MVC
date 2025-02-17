using Microsoft.AspNetCore.Mvc;

namespace Task2.Controllers
{
    public class UserController : Controller
    {
        public IActionResult User()
        {
            return View();
        }
    }
}

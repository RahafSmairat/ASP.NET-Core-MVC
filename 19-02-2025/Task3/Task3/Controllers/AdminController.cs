using Microsoft.AspNetCore.Mvc;

namespace Task3.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminDashboard()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Index" , "Home");
        }
    }
}

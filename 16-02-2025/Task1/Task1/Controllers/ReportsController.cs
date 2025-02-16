using Microsoft.AspNetCore.Mvc;

namespace Task1.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Reports()
        {
            return View();
        }
    }
}

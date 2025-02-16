using Microsoft.AspNetCore.Mvc;

namespace Task1.Controllers
{
    public class ProgramsController : Controller
    {
        public IActionResult Programs()
        {
            return View();
        }
    }
}

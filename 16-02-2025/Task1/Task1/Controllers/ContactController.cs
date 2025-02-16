using Microsoft.AspNetCore.Mvc;

namespace Task1.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }
    }
}

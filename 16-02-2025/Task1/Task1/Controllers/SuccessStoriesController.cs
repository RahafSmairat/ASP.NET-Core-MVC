using Microsoft.AspNetCore.Mvc;

namespace Task1.Controllers
{
    public class SuccessStoriesController : Controller
    {
        public IActionResult SuccessStories()
        {
            return View();
        }
    }
}

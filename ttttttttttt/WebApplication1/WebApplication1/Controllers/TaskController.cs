using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TaskController : Controller
    {
        private readonly MyDbContext _context;

        public TaskController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create(int managerId)
        {
            ViewBag.Employees = _context.Employees.Where(e => e.ManagerId == managerId).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Taskk task)
        {
            _context.Taskks.Add(task);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Manager");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

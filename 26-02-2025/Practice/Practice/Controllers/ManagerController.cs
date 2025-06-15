using Microsoft.AspNetCore.Mvc;
using Practice.Models;
using System;

namespace Practice.Controllers
{
    public class ManagerController : Controller
    {
        private readonly MyDbContext _context;

        public ManagerController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var managers = _context.Managers.ToList();
            return View(managers);
        }

        public IActionResult Employees(int id)
        {
            var employees = _context.Employees.Where(e => e.ManagerId == id).ToList();
            return View(employees);
        }
    }
}

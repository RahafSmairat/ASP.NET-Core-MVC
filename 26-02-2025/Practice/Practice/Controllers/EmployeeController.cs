using Microsoft.AspNetCore.Mvc;
using Practice.Models;
using System;

namespace Practice.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public EmployeeController(MyDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Create(int managerId)
        {
            ViewBag.ManagerId = managerId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                string imagesFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                string filePath = Path.Combine(imagesFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                employee.ImagePath = "/images/" + uniqueFileName;
            }

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Manager");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
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

                string filePath = Path.Combine(imagesFolder, imageFile.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                employee.ImagePath = "/images/" + imageFile.FileName;
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

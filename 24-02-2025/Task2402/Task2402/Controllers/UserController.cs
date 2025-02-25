using Microsoft.AspNetCore.Mvc;
using Task2402.Models;

namespace Task2402.Controllers
{
    public class UserController : Controller
    {
        private readonly MyDbContext _context;

        public UserController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Userr user)
        {
            if (ModelState.IsValid)
            {
                _context.Userrs.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Userrs.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("Name", user.FullName);
                HttpContext.Session.SetString("Email", user.Email);
                HttpContext.Session.SetString("Role", user.Role);

                if (user.Role == "admin")
                    return RedirectToAction("Admin", "Admin");
                else if (user.Role == "superadmin")
                    return RedirectToAction("SuperAdmin", "Admin");
                else
                    return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "Wrong email or password!";
            return View();
        }

        public IActionResult Profile()
        {
            ViewData["Name"] = HttpContext.Session.GetString("Name");
            ViewData["Email"] = HttpContext.Session.GetString("Email");

            return View();
        }
        public IActionResult EditProfile()
        {
            int? Id = HttpContext.Session.GetInt32("UserId");
            var user = _context.Userrs.Find(Id);
            return View(user);
        }

        [HttpPost]
        public IActionResult EditProfile(Userr user)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            var user1 = _context.Userrs.Find(userId);
            user1.FullName = user.FullName;
            _context.Userrs.Update(user1);
            _context.SaveChanges();
            HttpContext.Session.SetString("Name", user1.FullName);
            return View(user1);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}

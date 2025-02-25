using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task2402.Models;

namespace Task2402.Controllers
{
    public class AdminController : Controller
    {
        private readonly MyDbContext _context;

        public AdminController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Admin()
        {
            return View();
        }
        public IActionResult SuperAdmin()
        {
            return View();
        }

        public IActionResult UsersDetails()
        {
            var users = _context.Userrs.ToList();
            return View(users);
        }

        public IActionResult Delete(int Id)
        {
            var user = _context.Userrs.Find(Id);

            _context.Userrs.Remove(user);
            _context.SaveChanges();

            return RedirectToAction("UsersDetails");
        }

        public IActionResult EditUser(int Id)
        {
            var user = _context.Userrs.Find(Id);
            return View(user);
        }

        [HttpPost]
        public IActionResult EditUser(Userr user)
        {
            var existingUser = _context.Userrs.Find(user.Id);
            existingUser.FullName = user.FullName;
            existingUser.Email = user.Email;
            _context.SaveChanges();
            return RedirectToAction("UsersDetails");
        }
    }
}

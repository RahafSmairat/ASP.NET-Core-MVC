using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Task2302.Models;

namespace Task2302.Controllers;

public class HomeController : Controller
{
    private readonly MyDbContext _context;

    public HomeController(MyDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var users = _context.Users.ToList();
        return View(users);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Privacy(User user)
    {
        _context.Add(user);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int UserId)
    {
        var user = _context.Users.Find(UserId);
        return View(user);
    }

    [HttpPost]
    public IActionResult Edit(User user)
    {
        //var existingUser = _context.Users.Find(user.UserId);
        //existingUser.FirstName = user.FirstName;
        //existingUser.Email = user.Email;
        _context.Users.Update(user);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int UserId)
    {
        var user = _context.Users.Find(UserId);

        _context.Users.Remove(user);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Details(int UserId)
    {
        var user = _context.Users.Find(UserId); 
        return View(user);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

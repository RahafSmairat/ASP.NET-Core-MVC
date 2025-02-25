using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Task2402.Models;

namespace Task2402.Controllers;

public class HomeController : Controller
{
    private readonly MyDbContext _context;

    public HomeController(MyDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Name")))
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Products()
    {
        var products = _context.Products.ToList();
        return View(products);
    }

    public IActionResult AddProduct()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        _context.Add(product);
        _context.SaveChanges();
        return RedirectToAction("Products");
    }

    public IActionResult Details(int Id)
    {
        var product = _context.Products.Find(Id);
        return View(product);
    }

    public IActionResult Delete(int Id)
    {
        var product = _context.Products.Find(Id);

        _context.Products.Remove(product);
        _context.SaveChanges();

        return RedirectToAction("Products");
    }

    public IActionResult Edit(int Id)
    {
        var product = _context.Products.Find(Id);
        return View(product);
    }

    [HttpPost]
    public IActionResult Edit(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
        return RedirectToAction("Products");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

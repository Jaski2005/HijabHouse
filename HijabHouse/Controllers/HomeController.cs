using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HijabHouse.Models;
using HijabHouse.Data;

namespace HijabHouse.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Collection()
    {
        var dresses = _context.Dresses.ToList();

        return View(dresses);
    }

    public IActionResult Details(int id)
    {
        var dress = _context.Dresses
         .FirstOrDefault(d => d.Id == id);

         if (dress == null)
        {
            return NotFound();
        }

        return View(dress);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

using Microsoft.AspNetCore.Mvc;
using HijabHouse.Data;
using HijabHouse.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HijabHouse.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var orderCount = _context.Orders.Count();
            var dressCount = _context.Dresses.Count();

            ViewBag.OrderCount = orderCount;
            ViewBag.DressCount = dressCount;

            return View();
        }
        public IActionResult Orders()
        {
            if (HttpContext.Session.GetString("IsAdmin") != "True")
            {
                return RedirectToAction("Index", "Home");
            }

            var orders = _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Dress)
                .OrderByDescending(o => o.OrderDate)
                .ToList();

            return View(orders);
        }
    }
}
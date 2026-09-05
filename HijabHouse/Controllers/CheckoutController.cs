using Microsoft.AspNetCore.Mvc;
using HijabHouse.Data;
using HijabHouse.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HijabHouse.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CheckoutController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cartItems = _context.CartItems
                .Include(c => c.Dress)
                .ToList();

            if (cartItems.Count == 0)
            {
                return RedirectToAction("Index", "Cart");
            }

            return View(cartItems);
        }

        [HttpPost]
        public IActionResult Confirm(Order order)
        {
            var cartItems = _context.CartItems
                .Include(c => c.Dress)
                .ToList();

            if (cartItems.Count == 0)
            {
                return RedirectToAction("Index", "Cart");
            }

            decimal total = 0;

            foreach (var item in cartItems)
            {
                total += item.Dress.Price * item.Quantity;
            }

            order.Total = total;
            order.OrderDate = DateTime.Now;

            _context.Orders.Add(order);
            _context.SaveChanges();

            foreach (var item in cartItems)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    DressId = item.DressId,
                    Quantity = item.Quantity,
                    Price = item.Dress.Price
                };

                _context.OrderItems.Add(orderItem);
            }

            _context.SaveChanges();

            _context.CartItems.RemoveRange(cartItems);
            _context.SaveChanges();

            return RedirectToAction("Success");
        }
    public IActionResult Success()
        {
            return View();
        }
    }
}
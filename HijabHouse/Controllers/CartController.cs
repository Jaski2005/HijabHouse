using Microsoft.AspNetCore.Mvc;
using HijabHouse.Data;
using HijabHouse.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HijabHouse.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cartItems = _context.CartItems
                 .Include(c => c.Dress)
                 .ToList();

            return View(cartItems);
        }

        [HttpPost]
        public IActionResult Add(int dressId)
        {
            var dress = _context.Dresses
              .FirstOrDefault(d => d.Id == dressId);

            if (dress == null)
            {
                return NotFound();
            }

            var cartItem = new CartItem
            {
                DressId = dressId,
                UserId = 1,
                Quantity = 1
            };

            _context.CartItems.Add(cartItem);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var cartItem = _context.CartItems
                .FirstOrDefault(c => c.Id == id);

            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Increase(int id)
        {
            var cartItem = _context.CartItems
                .FirstOrDefault(c => c.Id == id);

                if(cartItem != null)
            {
                cartItem.Quantity++;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Decrease(int id)
        {
            var cartItem = _context.CartItems
                .FirstOrDefault(c => c.Id == id);

                if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
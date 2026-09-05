using Microsoft.AspNetCore.Mvc;
using HijabHouse.Data;
using HijabHouse.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace HijabHouse.Controllers
{
    public class AccountController : Controller
    {
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        //LOGIN - GET
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // LOGIN - POST
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.User
                .FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("UserName", user.Name);
                HttpContext.Session.SetString("UserEmail", user.Email);
                HttpContext.Session.SetString("IsAdmin", user.IsAdmin.ToString());

                if (user.IsAdmin)
                {
                    return RedirectToAction("orders", "Admin");
                }

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Emaili ose fjalkalimi i gabuar. ";
            return View();
        }

        // REGISTER - GET
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //REGISTER - POST
        [HttpPost]
        public IActionResult Register(string name, string email, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                ViewBag.Error = "Fjalkalimet nuk perputhen.";
                return View();
            }
            
            var existingUser =_context.User
                .FirstOrDefault(u => u.Email == email);

            if (existingUser != null)
            {
                ViewBag.Error = "Ky email eshte rregjistruar me pare.";
                return View();
            }

            var user = new User
            {
                Name = name,
                Email = email,
                Password = password
            };

            _context.User.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        //LOGOUT
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}
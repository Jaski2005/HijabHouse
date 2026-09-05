using Microsoft.AspNetCore.Mvc;
using HijabHouse.Data;
using System.Linq;
using HijabHouse.Models;

namespace HijabHouse.Controllers
{
    public class DressController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DressController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Kodi per te shfaq fustanet
        public IActionResult Index()
        {
            var dresses = _context.Dresses.ToList();

            return View(dresses);
        }

        //CREATE - GET
        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("IsAdmin") != "True")
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        //CREATE - POST
        [HttpPost]
        public IActionResult Create(Dress dress)
        {
            if (HttpContext.Session.GetString("IsAdmin") != "True")
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                _context.Dresses.Add(dress);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(dress);
        }

        //DETAILS
        public IActionResult Details(int id)
        {
            var dress = _context.Dresses.FirstOrDefault(d => d.Id == id);

            if (dress == null)
            {
                return NotFound();
            }

            return View(dress);
        }

        // EDIT - GET
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var dress = _context.Dresses.FirstOrDefault(d => d.Id == id);

            if (dress == null)
            {
                return NotFound();
            }

            return View(dress);
        }

        // EDIT - POST
        [HttpPost]
        public IActionResult Edit(Dress dress)
        {
            if (HttpContext.Session.GetString("IsAdmin") != "True")
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                _context.Dresses.Update(dress);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(dress);
        }

        //DELETE
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("IsAdmin") != "True")
            {
                return RedirectToAction("Index", "Home");
            }
            var dress = _context.Dresses.FirstOrDefault(d => d.Id == id);

            if (dress == null)
            {
                return NotFound();
            }

            _context.Dresses.Remove(dress);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
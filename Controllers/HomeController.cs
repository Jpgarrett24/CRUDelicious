using System;
using System.Linq;
using System.Collections.Generic;
using CRUDelicious.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.AllDishes = _context.Dishes.ToList();
            return View("Index");
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View("NewDish");
        }

        [HttpPost("create")]
        public IActionResult CreateDish(Dish Form)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Form);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return New();
            }
        }

        [HttpGet("{id}")]
        public IActionResult DishDetails(int id)
        {
            ViewBag.Dish = _context.Dishes.FirstOrDefault(d => d.DishId == id);
            if (ViewBag.Dish == null)
            {
                return RedirectToAction("Index");
            }
            return View("DishDetails");
        }

        [HttpGet("/dish/delete/{id}")]
        public IActionResult DeleteDish(int id)
        {
            Dish ToDelete = _context.Dishes.FirstOrDefault(d => d.DishId == id);

            if (ToDelete == null)
            {
                return RedirectToAction("Index");
            }
            _context.Remove(ToDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("/dish/edit/{id}")]
        public IActionResult EditForm(int id)
        {
            ViewBag.Dish = _context.Dishes.FirstOrDefault(d => d.DishId == id);
            if (ViewBag.Dish == null)
            {
                return RedirectToAction("Index");
            }
            return View("EditDish");
        }

        [HttpPost("/dish/update/{id}")]
        public IActionResult EditDish(int id, Dish Form)
        {
            if (ModelState.IsValid)
            {
                Form.DishId = id;
                _context.Update(Form);
                _context.Entry(Form).Property("CreatedAt").IsModified = false;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return EditForm(id);
            }
        }
    }
}
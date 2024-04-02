using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var orders = _context.CanteenOrders.ToList();
            return View(orders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CanteenOrder canteenOrder)
        {
            if (ModelState.IsValid)
            {
                canteenOrder.OrderDate = DateTime.Now; // Set Order Date
                _context.Add(canteenOrder);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(canteenOrder);
        }
    }
}

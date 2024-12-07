using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BOROMOTORS.Data;
using BOROMOTORS.Models;

namespace BOROMOTORS.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Order
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders.Include(o => o.DirtBike).Include(o => o.Customer).ToListAsync();
            return View(orders);
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            ViewData["DirtBikeId"] = new SelectList(_context.DirtBikes, "Id", "Model");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name");
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DirtBikeId,CustomerId,OrderDate,TotalPrice")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.OrderDate = DateTime.Now;
                var dirtBike = await _context.DirtBikes.FindAsync(order.DirtBikeId);
                order.TotalPrice = (decimal)dirtBike.Price;

                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DirtBikeId"] = new SelectList(_context.DirtBikes, "Id", "Model", order.DirtBikeId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", order.CustomerId);
            return View(order);
        }
    }
}

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
    public class DirtBikeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DirtBikeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DirtBike
        public IActionResult Index()
        {
            var DirtBikes = _context.DirtBikes.ToList();
            return View(DirtBikes);
        }

        // GET: DirtBike/List
        public async Task<IActionResult> List()
        {
            var dirtBikes = await _context.DirtBikes.ToListAsync();
            return View(dirtBikes);
        }

        // GET: DirtBike/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dirtBike = await _context.DirtBikes 
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dirtBike == null)
            {
                return NotFound();
            }

            return View(dirtBike);
        }

        // POST: DirtBike/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,Manufacturer,Price,Stock,Description,ImageUrl,VideoUrl,TopSpeed,Horsepower,Weight")] DirtBike dirtBike)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dirtBike);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dirtBike);
        }

        // GET: DirtBike/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dirtBike = await _context.DirtBikes.FindAsync(id);
            if (dirtBike == null)
            {
                return NotFound();
            }
            return View(dirtBike);
        }

        // POST: DirtBike/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,Manufacturer,Price,Stock,Description,ImageUrl,VideoUrl,TopSpeed,Horsepower,Weight")] DirtBike dirtBike)
        {
            if (id != dirtBike.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dirtBike);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirtBikeExists(dirtBike.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dirtBike);
        }

        // GET: DirtBike/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dirtBike = await _context.DirtBikes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dirtBike == null)
            {
                return NotFound();
            }

            return View(dirtBike);
        }

        // POST: DirtBike/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dirtBike = await _context.DirtBikes.FindAsync(id);
            if (dirtBike != null)
            {
                _context.DirtBikes.Remove(dirtBike);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool DirtBikeExists(int? id)
        {
            return _context.DirtBikes.Any(e => e.Id == id);
        }

    }
}
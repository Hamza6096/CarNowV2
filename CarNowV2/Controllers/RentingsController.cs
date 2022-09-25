using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarNow.Models;
using CarNowV2.Data;

namespace CarNowV2.Controllers
{
    public class RentingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rentings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Renting.Include(r => r.Car);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Rentings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Renting == null)
            {
                return NotFound();
            }

            var renting = await _context.Renting
                .Include(r => r.Car)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (renting == null)
            {
                return NotFound();
            }

            return View(renting);
        }

        // GET: Rentings/Create
        public IActionResult Create()
        {
            ViewData["CarID"] = new SelectList(_context.Car, "Id", "Address");
            return View();
        }

        // POST: Rentings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentingID,Start,End,IsValidate,PaymentDate,Amount,TypeOfPayment,PlannedDuration,RealDuration,DailyPrice,CarID,Id")] Renting renting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(renting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarID"] = new SelectList(_context.Car, "Id", "Address", renting.CarID);
            return View(renting);
        }

        // GET: Rentings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Renting == null)
            {
                return NotFound();
            }

            var renting = await _context.Renting.FindAsync(id);
            if (renting == null)
            {
                return NotFound();
            }
            ViewData["CarID"] = new SelectList(_context.Car, "Id", "Address", renting.CarID);
            return View(renting);
        }

        // POST: Rentings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentingID,Start,End,IsValidate,PaymentDate,Amount,TypeOfPayment,PlannedDuration,RealDuration,DailyPrice,CarID,Id")] Renting renting)
        {
            if (id != renting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(renting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentingExists(renting.Id))
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
            ViewData["CarID"] = new SelectList(_context.Car, "Id", "Address", renting.CarID);
            return View(renting);
        }

        // GET: Rentings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Renting == null)
            {
                return NotFound();
            }

            var renting = await _context.Renting
                .Include(r => r.Car)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (renting == null)
            {
                return NotFound();
            }

            return View(renting);
        }

        // POST: Rentings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Renting == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Renting'  is null.");
            }
            var renting = await _context.Renting.FindAsync(id);
            if (renting != null)
            {
                _context.Renting.Remove(renting);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentingExists(int id)
        {
          return _context.Renting.Any(e => e.Id == id);
        }
    }
}

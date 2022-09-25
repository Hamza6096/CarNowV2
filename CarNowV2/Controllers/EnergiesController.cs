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
    public class EnergiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnergiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Energies
        public async Task<IActionResult> Index()
        {
              return View(await _context.Energy.ToListAsync());
        }

        // GET: Energies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Energy == null)
            {
                return NotFound();
            }

            var energy = await _context.Energy
                .FirstOrDefaultAsync(m => m.EnergyID == id);
            if (energy == null)
            {
                return NotFound();
            }

            return View(energy);
        }

        // GET: Energies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Energies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnergyID,Name")] Energy energy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(energy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(energy);
        }

        // GET: Energies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Energy == null)
            {
                return NotFound();
            }

            var energy = await _context.Energy.FindAsync(id);
            if (energy == null)
            {
                return NotFound();
            }
            return View(energy);
        }

        // POST: Energies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnergyID,Name")] Energy energy)
        {
            if (id != energy.EnergyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(energy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnergyExists(energy.EnergyID))
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
            return View(energy);
        }

        // GET: Energies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Energy == null)
            {
                return NotFound();
            }

            var energy = await _context.Energy
                .FirstOrDefaultAsync(m => m.EnergyID == id);
            if (energy == null)
            {
                return NotFound();
            }

            return View(energy);
        }

        // POST: Energies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Energy == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Energy'  is null.");
            }
            var energy = await _context.Energy.FindAsync(id);
            if (energy != null)
            {
                _context.Energy.Remove(energy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnergyExists(int id)
        {
          return _context.Energy.Any(e => e.EnergyID == id);
        }
    }
}

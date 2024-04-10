using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectRunAway.Models;

namespace ProjectRunAway.Controllers
{
    public class LiabilitiesController : Controller
    {
        private readonly TableContext _context;

        public LiabilitiesController(TableContext context)
        {
            _context = context;
        }

        // GET: Liabilities
        public async Task<IActionResult> Index()
        {
            var tableContext = _context.Liability.Include(l => l.Cars);
            return View(await tableContext.ToListAsync());
        }

        // GET: Liabilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liability = await _context.Liability
                .Include(l => l.Cars)
                .FirstOrDefaultAsync(m => m.LiabilityId == id);
            if (liability == null)
            {
                return NotFound();
            }

            return View(liability);
        }

        // GET: Liabilities/Create
        public IActionResult Create()
        {
            ViewData["CarsId"] = new SelectList(_context.Cars, "CarsId", "CarsId");
            return View();
        }

        // POST: Liabilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LiabilityId,Category,Price_liability,About,CarsId")] Liability liability)
        {
            if (ModelState.IsValid)
            {
                _context.Add(liability);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarsId"] = new SelectList(_context.Cars, "CarsId", "CarsId", liability.CarsId);
            return View(liability);
        }

        // GET: Liabilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liability = await _context.Liability.FindAsync(id);
            if (liability == null)
            {
                return NotFound();
            }
            ViewData["CarsId"] = new SelectList(_context.Cars, "CarsId", "CarsId", liability.CarsId);
            return View(liability);
        }

        // POST: Liabilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LiabilityId,Category,Price_liability,About,CarsId")] Liability liability)
        {
            if (id != liability.LiabilityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(liability);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LiabilityExists(liability.LiabilityId))
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
            ViewData["CarsId"] = new SelectList(_context.Cars, "CarsId", "CarsId", liability.CarsId);
            return View(liability);
        }

        // GET: Liabilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liability = await _context.Liability
                .Include(l => l.Cars)
                .FirstOrDefaultAsync(m => m.LiabilityId == id);
            if (liability == null)
            {
                return NotFound();
            }

            return View(liability);
        }

        // POST: Liabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var liability = await _context.Liability.FindAsync(id);
            if (liability != null)
            {
                _context.Liability.Remove(liability);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LiabilityExists(int id)
        {
            return _context.Liability.Any(e => e.LiabilityId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectRunAway.Models;

namespace ProjectRunAway.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly TableContext _context;

        public FeaturesController(TableContext context)
        {
            _context = context;
        }

        // GET: Features
<<<<<<< Updated upstream
        public async Task<IActionResult> Index()
=======
        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
>>>>>>> Stashed changes
        {
            var tableContext = _context.Features.Include(f => f.Cars);
            return View(await tableContext.ToListAsync());
        }

        // GET: Features/Details/5
<<<<<<< Updated upstream
        public async Task<IActionResult> Details(int? id)
=======
        [Authorize(Roles = "Administrator")]
        public IActionResult Details(int? id)
>>>>>>> Stashed changes
        {
            if (id == null)
            {
                return NotFound();
            }

            var features = await _context.Features
                .Include(f => f.Cars)
                .FirstOrDefaultAsync(m => m.FeaturesId == id);
            if (features == null)
            {
                return NotFound();
            }

            return View(features);
        }

        // GET: Features/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            ViewData["CarsId"] = new SelectList(_context.Cars, "CarsId", "CarsId");
            return View();
        }

        // POST: Features/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeaturesId,AC,Headted_seats,Ventilated_seats,Steering_wheel_heating,Material_of_the_seats,Navigation,HorsePower,Cilindrical_capacity,HeadLights,Type_seats,Virtual_cockpit,Sunroof,CarsId")] Features features)
        {
            if (ModelState.IsValid)
            {
                _context.Add(features);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarsId"] = new SelectList(_context.Cars, "CarsId", "CarsId", features.CarsId);
            return View(features);
        }

        // GET: Features/Edit/5
<<<<<<< Updated upstream
        public async Task<IActionResult> Edit(int? id)
=======
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int? id)
>>>>>>> Stashed changes
        {
            if (id == null)
            {
                return NotFound();
            }

            var features = await _context.Features.FindAsync(id);
            if (features == null)
            {
                return NotFound();
            }
            ViewData["CarsId"] = new SelectList(_context.Cars, "CarsId", "CarsId", features.CarsId);
            return View(features);
        }

        // POST: Features/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeaturesId,AC,Headted_seats,Ventilated_seats,Steering_wheel_heating,Material_of_the_seats,Navigation,HorsePower,Cilindrical_capacity,HeadLights,Type_seats,Virtual_cockpit,Sunroof,CarsId")] Features features)
        {
            if (id != features.FeaturesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(features);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeaturesExists(features.FeaturesId))
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
            ViewData["CarsId"] = new SelectList(_context.Cars, "CarsId", "CarsId", features.CarsId);
            return View(features);
        }

        // GET: Features/Delete/5
<<<<<<< Updated upstream
        public async Task<IActionResult> Delete(int? id)
=======
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int? id)
>>>>>>> Stashed changes
        {
            if (id == null)
            {
                return NotFound();
            }

            var features = await _context.Features
                .Include(f => f.Cars)
                .FirstOrDefaultAsync(m => m.FeaturesId == id);
            if (features == null)
            {
                return NotFound();
            }

            return View(features);
        }

        // POST: Features/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var features = await _context.Features.FindAsync(id);
            if (features != null)
            {
                _context.Features.Remove(features);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeaturesExists(int id)
        {
            return _context.Features.Any(e => e.FeaturesId == id);
        }
    }
}

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
    public class AvailabilitiesController : Controller
    {
        private readonly TableContext _context;

        public AvailabilitiesController(TableContext context)
        {
            _context = context;
        }

        // GET: Availabilities
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            var tableContext = _context.Availability.Include(a => a.Cars).Include(a => a.Locations);
            return View(await tableContext.ToListAsync());
        }

        // GET: Availabilities/Details/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availability = await _context.Availability
                .Include(a => a.Cars)
                .Include(a => a.Locations)
                .FirstOrDefaultAsync(m => m.CarsId == id);
            if (availability == null)
            {
                return NotFound();
            }

            return View(availability);
        }

        // GET: Availabilities/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            ViewData["CarsId"] = new SelectList(_context.Cars, "CarsId", "CarsId");
            ViewData["LocationsId"] = new SelectList(_context.Locations, "LocationsId", "LocationsId");
            return View();
        }

        // POST: Availabilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusyCar,DateStart,DateEnd,FromHour,ToHour,CarsId,LocationsId")] Availability availability)
        {
            if (ModelState.IsValid)
            {
                _context.Add(availability);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarsId"] = new SelectList(_context.Cars, "CarsId", "CarsId", availability.CarsId);
            ViewData["LocationsId"] = new SelectList(_context.Locations, "LocationsId", "LocationsId", availability.LocationsId);
            return View(availability);
        }

        // GET: Availabilities/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availability = await _context.Availability.FindAsync(id);
            if (availability == null)
            {
                return NotFound();
            }
            ViewData["CarsId"] = new SelectList(_context.Cars, "CarsId", "CarsId", availability.CarsId);
            ViewData["LocationsId"] = new SelectList(_context.Locations, "LocationsId", "LocationsId", availability.LocationsId);
            return View(availability);
        }

        // POST: Availabilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BusyCar,DateStart,DateEnd,FromHour,ToHour,CarsId,LocationsId")] Availability availability)
        {
            if (id != availability.CarsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(availability);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvailabilityExists(availability.CarsId))
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
            ViewData["CarsId"] = new SelectList(_context.Cars, "CarsId", "CarsId", availability.CarsId);
            ViewData["LocationsId"] = new SelectList(_context.Locations, "LocationsId", "LocationsId", availability.LocationsId);
            return View(availability);
        }
        [HttpPost]
        public IActionResult MarkCarAsBusy(int carId)
        {
            if (carId == 0)
            {
               
                return RedirectToAction("Index");
            }

            var availability = _context.Availability.FirstOrDefault(a => a.CarsId == carId);
            if (availability != null)
            {
                availability.BusyCar = "true"; 
                _context.Update(availability);
                _context.SaveChanges();
            }
            return RedirectToAction("ConfirmOrder","Extra");
        }



        // GET: Availabilities/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availability = await _context.Availability
                .Include(a => a.Cars)
                .Include(a => a.Locations)
                .FirstOrDefaultAsync(m => m.CarsId == id);
            if (availability == null)
            {
                return NotFound();
            }

            return View(availability);
        }

        // POST: Availabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var availability = await _context.Availability.FindAsync(id);
            if (availability != null)
            {
                _context.Availability.Remove(availability);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvailabilityExists(int id)
        {
            return _context.Availability.Any(e => e.CarsId == id);
        }
    }
}

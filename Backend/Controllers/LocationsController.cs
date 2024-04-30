using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectRunAway.Models;
using ProjectRunAway.Services.Interfaces;

namespace ProjectRunAway.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        // GET: Locations
        public IActionResult Index()
        {
            var locations = _locationService.GetAllLocations();
            return View(locations);
        }

        // GET: Locations/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locations = _locationService.GetLocationById(id.Value);
                

            if (locations == null)
            {
                return NotFound();
            }

            return View(locations);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Locations/AdminLocation
        public ActionResult AdminLocation()
        {
            var locations = _locationService.GetAllLocations();
            return View(locations);
        }


        // POST: Locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("LocationsId,City,CarsAvailable,Description")] Locations locations)
        {
            if (ModelState.IsValid)
            {
                _locationService.AddLocation(locations);
                _locationService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(locations);
        }

        // GET: Locations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locations = _locationService.EditExisting().FirstOrDefault(m => m.LocationsId == id);
            if (locations == null)
            {
                return NotFound();
            }
            return View(locations);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("LocationsId,City,CarsAvailable,Description")] Locations locations)
        {
            if (id != locations.LocationsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                 
                    _locationService.UpdateLocation(locations);
                    _locationService.Save();
                    return RedirectToAction(nameof(Index));
            }
            return View(locations);
        }

        // GET: Locations/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locations = _locationService.GetLocationById(id.Value);
               
            if (locations == null)
            {
                return NotFound();
            }

            return View(locations);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(int id)
        {
            var locations = _locationService.GetLocationById(id);
            if (locations != null)
            {
                _locationService.DeleteLocation(locations);
                _locationService.Save();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

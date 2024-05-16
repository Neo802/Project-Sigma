<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
=======
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
>>>>>>> Stashed changes
using Microsoft.EntityFrameworkCore;
using ProjectRunAway.Models;

namespace ProjectRunAway.Controllers
{
    public class CarsController : Controller
    {
        private readonly TableContext _context;

<<<<<<< Updated upstream
        public CarsController(TableContext context)
=======
            return Json(car);
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult AdminCars()
>>>>>>> Stashed changes
        {
            _context = context;
        }

        // GET: Cars
        /*
        public async Task<IActionResult> Index()
        {
            var tableContext = _context.Cars.Include(c => c.Users);
            return View(await tableContext.ToListAsync());
        }
        */

        // GET: Cars
        public async Task<IActionResult> Index(string carMake, string carModel, string searchText, float price, string fuelType, string bodyType, string seating)
        {
            IQueryable<Cars> query = _context.Cars.Include(c => c.Users);

            if (!string.IsNullOrEmpty(carMake))
            {
                query = query.Where(c => c.Manufacturer == carMake);
            }

            if (!string.IsNullOrEmpty(carModel))
            {
                query = query.Where(c => c.Model == carModel);
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(c => c.Manufacturer.Contains(searchText) || c.Model.Contains(searchText));
            }

            if (price != 0)
            {
                query = query.Where(c => c.PriceCar == price);
            }

            if (!string.IsNullOrEmpty(fuelType))
            {
                query = query.Where(c => c.Fuel == fuelType);
            }

            if (!string.IsNullOrEmpty(bodyType))
            {
                query = query.Where(c => c.Type == bodyType);
            }

            if (!string.IsNullOrEmpty(seating))
            {
                query = query.Where(c => c.Seats == seating);
            }

            return View(await query.ToListAsync());
        }


        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cars = await _context.Cars
                .Include(c => c.Users)
                .FirstOrDefaultAsync(m => m.CarsId == id);
            if (cars == null)
            {
                return NotFound();
            }

            return View(cars);
        }

<<<<<<< Updated upstream
        private bool CarsExists(int id)
=======
        // GET: Cars/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
>>>>>>> Stashed changes
        {
            return _context.Cars.Any(e => e.CarsId == id);
        }
<<<<<<< Updated upstream
=======

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create([Bind("CarsId,Manufacturer,Model,Description,Fuel,Seats,Gear,Type,Doors,PriceCar,TankCapacity")] Cars cars)
        {
            if (ModelState.IsValid)
            {
                _carsServices.AddCars(cars);
                //_carsServices.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(cars);
        }

        // GET: Cars/Edit/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cars = _carsServices.EditExisting().FirstOrDefault(m => m.CarsId == id);
            if (cars == null)
            {
                return NotFound();
            }
            return View(cars);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CarsId,Manufacturer,Model,Description,Fuel,Seats,Gear,Type,Doors,PriceCar,TankCapacity")] Cars cars)
        {
            if (id != cars.CarsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _carsServices.UpdateCars(cars);
                return RedirectToAction(nameof(Index));
            }
            return View(cars);
        }

        // GET: Cars/Delete/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cars = _carsServices.GetCarsById(id.Value);

            if (cars == null)
            {
                return NotFound();
            }

            return View(cars);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var cars = _carsServices.GetCarsById(id);
            if (cars != null)
            {
                _carsServices.DeleteCars(cars);
                //_carsServices.Save();
            }
            return RedirectToAction(nameof(Index));
        }

>>>>>>> Stashed changes
    }
}

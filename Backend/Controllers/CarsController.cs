using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectRunAway.Models;

namespace ProjectRunAway.Controllers
{
    public class CarsController : Controller
    {
        private readonly TableContext _context;

        public CarsController(TableContext context)
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

        private bool CarsExists(int id)
        {
            return _context.Cars.Any(e => e.CarsId == id);
        }
    }
}

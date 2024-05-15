using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Versioning;
using ProjectRunAway.Models;
using ProjectRunAway.Services;
using ProjectRunAway.Services.Interfaces;

namespace ProjectRunAway.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsService _carsServices;
        public CarsController(ICarsService carsServices)
        {
            _carsServices = carsServices;
        }
        
        //public IActionResult GetCarDetails(int id)
        //{
        //    var car = _carsServices.GetCarsById(id);  // Make sure you have a method to fetch car by ID
        //    if (car == null)
        //        return NotFound();

        //    if (car.Features == null)
        //        return NotFound();

        //    var Features = car.Features.FirstOrDefault();

        //    return Json(Features);
        //}

        public IActionResult GetCarDetails(int id)
        {
            var car = _carsServices.GetCarWithFeatures(id);
            if (car == null)
                return NotFound();

            var result = new
            {
                manufacturer = car.Manufacturer,
                model = car.Model,
                description = car.Description,
                image = car.Image,

                fuel = car.Fuel,
                tankcapacity = car.TankCapacity,
                gear = car.Gear,

                f1 = car.Features.Select(g => g.VirtualCockpit).FirstOrDefault(),
                f2 = car.Features.Select(g => g.HorsePower).FirstOrDefault(),
                f3 = car.Features.Select(g => g.SunRoof).FirstOrDefault(),
                f4 = car.Features.Select(g => g.CilindricalCapacity).FirstOrDefault(),
                f5 = car.Features.Select(g => g.HeadLights).FirstOrDefault(),
                f6 = car.Features.Select(g => g.HeadtedSeats).FirstOrDefault(),
                f7 = car.Features.Select(g => g.AC).FirstOrDefault(),
                f8 = car.Features.Select(g => g.MaterialOfTheSeats).FirstOrDefault(),
                f9 = car.Features.Select(g => g.Navigation).FirstOrDefault(),
                f10 = car.Features.Select(g => g.SteeringWheelHeating).FirstOrDefault(),
                f11 = car.Features.Select(g => g.TypeSeats).FirstOrDefault(),
                f12 = car.Features.Select(g => g.VentilatedSeats).FirstOrDefault(),
            };

            return Json(result);
        }

        public ActionResult AdminCars()
        {
            var locations = _carsServices.GetAllCars();
            return View(locations);
        }
        public IActionResult Index(int locationId, string carMake, string carModel, string searchText, float priceMin, float priceMax, string fuelType, string bodyType, string seating, int sortType)
        {
            IQueryable<Cars> query = _carsServices.GetCarsByAvailabilityLocation(locationId).AsQueryable();
            
            if ((query == null || !query.Any()) && locationId == 0)
            {
                query = _carsServices.GetAllCars().AsQueryable();
            }
          
            if ((query == null || !query.Any())  && locationId != 0)
            {
                query = _carsServices.GetCarsByAvailabilityLocation(locationId).AsQueryable();
            }

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

            if (priceMin != 0)
            {
                query = query.Where(c => c.PriceCar >= Math.Min(priceMax, priceMin));
            }

            if (priceMax != 0)
            {
                query = query.Where(c => c.PriceCar <= Math.Max(priceMin, priceMax));
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

            if (sortType == 1)
            {
                return View(query.ToList().OrderBy(c => c.PriceCar));
                
            }else if (sortType == 2)
            {
                return View(query.ToList().OrderByDescending(c => c.PriceCar));
            }
           
            return View(query.ToList());
        }

        // GET: Cars/Details/5
        public IActionResult Details(int? id)
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

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CarsId,Manufacturer,Model,Description,Fuel,Seats,Gear,Type,Doors,PriceCar,TankCapacity,UsersId")] Cars cars)
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
        public IActionResult Edit(int id, [Bind("CarsId,Manufacturer,Model,Description,Fuel,Seats,Gear,Type,Doors,PriceCar,TankCapacity,UsersId")] Cars cars)
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

    }
}

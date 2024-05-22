using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectRunAway.Models;
using ProjectRunAway.Services.Interfaces;

namespace ProjectRunAway.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly IFeaturesService _featuresService;

        public FeaturesController(IFeaturesService featuresService)
        {
            _featuresService = featuresService;
        }
        // GET: Features

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            var features = _featuresService.GetAllFeatures();
            return View(features);
        }

        // GET: Features/Details/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var features = _featuresService.GetFeatureById(id.Value);
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
            return View();
        }

        // POST: Features/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FeaturesId,AC,HeadtedSeats,VentilatedSeats,SteeringWheelHeating,MaterialOfTheSeats,Navigation,HorsePower,CilindricalCapacity,HeadLights,TypeSeats,VirtualCockpit,SunRoof,CarsId")] Features features)
        {
            if (ModelState.IsValid)
            {
                _featuresService.AddFeature(features);
                return RedirectToAction(nameof(Index));
            }
            return View(features);
        }

        // GET: Features/Edit/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var features = _featuresService.EditExisting().FirstOrDefault(m => m.FeaturesId == id);
            if (features == null)
            {
                return NotFound();
            }
            return View(features);
        }

        // POST: Features/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeaturesId,AC,HeadtedSeats,VentilatedSeats,SteeringWheelHeating,MaterialOfTheSeats,Navigation,HorsePower,CilindricalCapacity,HeadLights,TypeSeats,VirtualCockpit,SunRoof,CarsId")] Features features)
        {
            if (id != features.FeaturesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                    _featuresService.UpdateFeature(features);
                    return RedirectToAction(nameof(Index));
            }
          
            return View(features);
        }

        // GET: Features/Delete/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var features = _featuresService.GetFeatureById(id.Value);
            if (features == null)
            {
                return NotFound();
            }

            return View(features);
        }

        // POST: Features/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var features = _featuresService.GetFeatureById(id);
            if (features != null)
            {
                _featuresService.DeleteFeature(features);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}

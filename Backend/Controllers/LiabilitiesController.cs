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
    public class LiabilitiesController : Controller
    {
        private readonly ILiabilitiesService _liabilityService;

        public LiabilitiesController(ILiabilitiesService liabilityService)
        {
            _liabilityService = liabilityService;
        }

        // GET: Liabilities
        public IActionResult Index()
        {
            var liability = _liabilityService.GetAllLiabilities();
            return View(liability);
        }

        // GET: Liabilities/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liability = _liabilityService.GetLiabilityById(id.Value);
            if (liability == null)
            {
                return NotFound();
            }

            return View(liability);
        }

        // GET: Liabilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Liabilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("LiabilityId,Category,PriceLiability,About,CarsId")] Liability liability)
        {
            if (ModelState.IsValid)
            {
                _liabilityService.AddLiability(liability);
                //_liabilityService.Save();
                return RedirectToAction(nameof(Index));
            }
           
            return View(liability);
        }

        // GET: Liabilities/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liability = _liabilityService.EditExisting().FirstOrDefault(m => m.LiabilityId == id);
            if (liability == null)
            {
                return NotFound();
            }
            
            return View(liability);
        }

        // POST: Liabilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("LiabilityId,Category,PriceLiability,About,CarsId")] Liability liability)
        {
            if (id != liability.LiabilityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              
                _liabilityService.UpdateLiability(liability);
               // _liabilityService.Save();
                return RedirectToAction(nameof(Index));
            }
            
            return View(liability);
        }

        // GET: Liabilities/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liability = _liabilityService.GetLiabilityById(id.Value);
            if (liability == null)
            {
                return NotFound();
            }

            return View(liability);
        }

        // POST: Liabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var liability = _liabilityService.GetLiabilityById(id);
            if (liability != null)
            {
                _liabilityService.DeleteLiability(liability);
               // _liabilityService.Save();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

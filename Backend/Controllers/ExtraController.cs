using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectRunAway.Models;
using ProjectRunAway.Services;
using ProjectRunAway.Services.Interfaces;


namespace ProjectRunAway.Controllers
{
    public class ExtraController : Controller
    {
        private readonly  IExtraService _extraService;

        public ExtraController(IExtraService extraService)
        {
            _extraService = extraService;
        }

        public IActionResult Index(int carsId)
        {
            var query = _extraService.GetExtraByCarId(carsId);

            return View(query);
        }
        public ActionResult AdminExtra()
        {
            var locations = _extraService.GetAllExtras();
            return View(locations);
        }
        // GET: Extra/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extra = _extraService.GetExtraById(id.Value);
            if (extra == null)
            {
                return NotFound();
            }

            return View(extra);
        }

        // GET: Extra/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Features/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ExtraId,AC,ChildSeat,TypeOfTires,SkiRack,WifiHotspot,SnowChains,RoadsideProtection,CarsId")] Extra extra)
        {
            if (ModelState.IsValid)
            {
                _extraService.AddExtra(extra);
                return RedirectToAction(nameof(Index));
            }
            return View(extra);
        }

        // GET: Features/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extra = _extraService.EditExisting().FirstOrDefault(m => m.ExtraId == id);
            if (extra == null)
            {
                return NotFound();
            }
            return View(extra);
        }

        // POST: Features/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ExtraId,AC,ChildSeat,TypeOfTires,SkiRack,WifiHotspot,SnowChains,RoadsideProtection,CarsId")] Extra extra)
        {
            if (id != extra.ExtraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _extraService.UpdateExtra(extra);
                return RedirectToAction(nameof(Index));
            }

            return View(extra);
        }

        // GET: Features/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extra = _extraService.GetExtraById(id.Value);
            if (extra == null)
            {
                return NotFound();
            }

            return View(extra);
        }

        // POST: Features/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var extra = _extraService.GetExtraById(id);
            if (extra != null)
            {
                _extraService.DeleteExtra(extra);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}


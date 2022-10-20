using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    public class PacchettoController : Controller
    {
        private TravelContext _db;

        public PacchettoController()
        {
            _db = new TravelContext();
        }
        public IActionResult Index()
        {
            List<PacchettoViaggio> packages = _db.PacchettoViaggio.ToList();

            return View(packages);
        }

        public IActionResult Details(int id)
        {
            PacchettoViaggio pack = _db.PacchettoViaggio.Find(id);
            return View(pack);
        }

        [HttpGet]
        public IActionResult Create()
        {
            PacchettoViaggio newPack = new PacchettoViaggio();
            return View(newPack);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Store(PacchettoViaggio pack)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", pack);
            }

            PacchettoViaggio newPack = new PacchettoViaggio(pack);

            _db.Add(pack);
            _db.SaveChanges();
            return View("Details", pack.Id);
        }
    }
}

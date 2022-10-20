using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    [Authorize]
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

            PacchettoViaggio newPack = new PacchettoViaggio();
            newPack.Name = pack.Name;
            newPack.Price = pack.Price;
            newPack.Days = pack.Days;
            newPack.Destination = pack.Destination;
            newPack.Image = pack.Image;
            newPack.Description = pack.Description;

            _db.PacchettoViaggio.Add(newPack);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            PacchettoViaggio pack = _db.PacchettoViaggio.Find(id);
            if(pack == null)
            {
                return NotFound();
            }

            return View("EditPack", pack);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePack(int id, PacchettoViaggio pack)
        {
            if (!ModelState.IsValid)
            {
                return View("EditPack", pack);
            }

            PacchettoViaggio packUpdate = _db.PacchettoViaggio.Find(id);

            if(packUpdate != null)
            {
                packUpdate.Name = pack.Name;
                packUpdate.Price = pack.Price;
                packUpdate.Image = pack.Image;
                packUpdate.Days = pack.Days;
                packUpdate.Destination = pack.Destination;
                packUpdate.Description = pack.Description;

                _db.SaveChanges();

            }
            else
            {
                return NotFound();
            }
            return RedirectToAction("Details", packUpdate);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _db.Remove(_db.PacchettoViaggio.Find(id));
            _db.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}

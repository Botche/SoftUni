using BandRegister.Models;
using Microsoft.AspNetCore.Mvc;
using BandRegister.Data;
using BandRegister.Models;
using System.Linq;

namespace BandRegister.Controllers
{
    public class BandController : Controller
    {
        public IActionResult Index()
        {
            using (var db=new BandContext())
            {
                var allBands = db.bands.ToList();
                return View(allBands);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Band band)
        {
            using (var db=new BandContext())
            {
                db.bands.Add(band);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db=new BandContext())
            {
                var bandToEdit = db.bands.Find(id);
                if(bandToEdit==null)
                    return RedirectToAction("Index");
                return View(bandToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Band band)
        {
            using (var db = new BandContext())
            {
                var bandToEdit = db.bands.FirstOrDefault(x => x.Id == band.Id);
                bandToEdit.Name = band.Name;
                bandToEdit.Members = band.Members;
                bandToEdit.Honorarium = band.Honorarium;
                bandToEdit.Genre = band.Genre;

                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new BandContext())
            {
                var bandToDelete = db.bands.Find(id);
                if (bandToDelete == null)
                    return RedirectToAction("Index");
                return View(bandToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Band band)
        {
            using (var db=new BandContext())
            {
                db.bands.Remove(band);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
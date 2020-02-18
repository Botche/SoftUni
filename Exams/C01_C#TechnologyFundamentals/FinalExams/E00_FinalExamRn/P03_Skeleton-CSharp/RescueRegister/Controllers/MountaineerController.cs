using RescueRegister.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace RescueRegister.Controllers
{
    public class MountaineerController : Controller
    {
        private readonly RescueRegisterDbContext context;

        public MountaineerController(RescueRegisterDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            using (var db=new RescueRegisterDbContext())
            {
                var allRescuers = db.Mountaineers.ToList();
                return View(allRescuers);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Mountaineer mountaineer)
        {
            using (var db = new RescueRegisterDbContext())
            {
                Mountaineer mountaineerToAdd = new Mountaineer();
                mountaineerToAdd.Name = mountaineer.Name;
                mountaineerToAdd.Age = mountaineer.Age;
                mountaineerToAdd.Gender = mountaineer.Gender;
                mountaineerToAdd.LastSeenDate = mountaineer.LastSeenDate;

                db.Mountaineers.Add(mountaineerToAdd);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db=new RescueRegisterDbContext())
            {
                var mountaineerToEdit = db.Mountaineers.Find(id);
                return View(mountaineerToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Mountaineer mountaineer)
        {
            using (var db=new RescueRegisterDbContext())
            {
                var mountaineerToEdit = db.Mountaineers.FirstOrDefault(x => x.Id == mountaineer.Id);
                mountaineerToEdit.Name = mountaineer.Name;
                mountaineerToEdit.Age = mountaineer.Age;
                mountaineerToEdit.Gender = mountaineer.Gender;
                mountaineerToEdit.LastSeenDate = mountaineer.LastSeenDate;

                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db=new RescueRegisterDbContext())
            {
                var mountaineerToDelete = db.Mountaineers.Find(id);
                return View(mountaineerToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Mountaineer mountaineer)
        {
            using (var db=new RescueRegisterDbContext())
            {
                var mountaineerToDelete = db.Mountaineers.FirstOrDefault(x => x.Id == mountaineer.Id);

                db.Mountaineers.Remove(mountaineerToDelete);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using GameStore.Data;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new GamesDbContext())
            {
                var games = db.Games.ToList();
                return View(games);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Game game)
        {
            if (game.Name == null || game.Price == 0 || game.Platform == null || game.Dlc == null)
            {
                return RedirectToAction("Index");
            }
            using (var db = new GamesDbContext())
            {
                db.Games.Add(game);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new GamesDbContext())
            {
                var gameToEdit = db.Games.Find(id);
                if (gameToEdit == null)
                    return RedirectToAction("Index");
                return View(gameToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Game game)
        {
            using (var db = new GamesDbContext())
            {
                var gameToEdit = db.Games.FirstOrDefault(x => x.Id == game.Id);
                gameToEdit.Name = game.Name;
                gameToEdit.Dlc = game.Dlc;
                gameToEdit.Price = game.Price;
                gameToEdit.Platform = game.Platform;

                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db=new GamesDbContext())
            {
                var gameToDelete = db.Games.Find(id);
                if (gameToDelete == null)
                    return RedirectToAction("Index");
                return View(gameToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Game game)
        {
            using (var db=new GamesDbContext())
            {
                var gameToDelete = db.Games.FirstOrDefault(x => x.Id == game.Id);

                db.Games.Remove(gameToDelete);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
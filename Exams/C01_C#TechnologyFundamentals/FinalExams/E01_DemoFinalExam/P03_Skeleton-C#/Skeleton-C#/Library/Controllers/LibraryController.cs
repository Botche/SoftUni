using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new LibraryDbContext())
            {
                var allBooks = db.books.ToList();
                return View(allBooks);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string title, string author, double price)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) || price < 1)
            {
                return RedirectToAction("Index");
            }

            Book book = new Book();
            book.Author = author;
            book.Title = title;
            book.Price = price;

            using (var db = new LibraryDbContext())
            {
                db.books.Add(book);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new LibraryDbContext())
            {
                var bookToEdit = db.books.Find(id);
                if (bookToEdit == null)
                    return RedirectToAction("Index");
                return View(bookToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            using (var db = new LibraryDbContext())
            {
                var taskToEdit = db.books.Find(book.Id);
                taskToEdit.Author = book.Author;
                taskToEdit.Price = book.Price;
                taskToEdit.Title = book.Title;

                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new LibraryDbContext())
            {
                var bookToDelete = db.books.Find(id);
                if (bookToDelete == null)
                    return RedirectToAction("Index");
                return View(bookToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            using (var db = new LibraryDbContext())
            {
                var taskToDelete = db.books.FirstOrDefault(x => x.Id == book.Id);
                db.books.Remove(taskToDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
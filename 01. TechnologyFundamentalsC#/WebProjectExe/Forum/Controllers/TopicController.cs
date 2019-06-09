using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Data;
using Forum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forum.Controllers
{
    public class TopicController : Controller
    {
        private readonly ForumDbContext context;

        public TopicController(ForumDbContext context)
        {
            this.context = context;
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Home");

            Topic topic = context.Topics
                .Include(x => x.Author)
                .Include(t => t.Category)
                .Include(t => t.Comments)
                .ThenInclude(c => c.Author)
                .Where(x => x.Id == id)
                .SingleOrDefault();

            if (topic == null)
                return RedirectToAction("Index", "Home");

            return View(topic);
        }

        [Authorize]
        public IActionResult Create()
        {
            var categoryNames = context.Categories.Select(c => c.Name).ToList();

            ViewData["CategoryNames"] = categoryNames;

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(string categoryName, Topic topic)
        {
            if (ModelState.IsValid)
            {
                topic.CreatedDate = DateTime.Now;
                topic.LastUpdatedDate = DateTime.Now;

                string authorId = context.Users
                    .Where(x => x.UserName == User.Identity.Name)
                    .First()
                    .Id;

                topic.AuthorId = authorId;

                if (!context.Categories.Any(c => c.Name == categoryName))
                    return View(topic);

                int categoryId = context.Categories.SingleOrDefault(c => c.Name == categoryName).Id;

                topic.CategoryId = categoryId;

                context.Topics.Add(topic);
                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(topic);
        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Home");

            var topic = context.Topics
                .Include(x => x.Author)
                .SingleOrDefault(m => m.Id == id);

            if (topic == null)
                return RedirectToAction("Index", "Home");

            return View(topic);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(int id)
        {
            Topic topic = context.Topics
                .Include(t => t.Author)
                .SingleOrDefault(m => m.Id == id);

            if (!topic.IsAuthor(User.Identity.Name))
            {
                return Forbid();
            }

            if (topic != null)
            {
                context.Topics.Remove(topic);
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Home");

            Topic topic = context.Topics
                .Include(x => x.Author)
                .Include(t => t.Category)
                .Where(t => t.Id == id)
                .SingleOrDefault();

            if (topic == null)
                return RedirectToAction("Index", "Home");

            if (!topic.IsAuthor(User.Identity.Name))
            {
                return Forbid();
            }

            List<string> categoryNames = context.Categories.Select(c => c.Name).ToList();

            ViewData["CategoryNames"] = categoryNames;

            return View(topic);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(string categoryName, Topic topic)
        {
            if (ModelState.IsValid)
            {
                Topic topicFromDb = context.Topics
                    .Include(t => t.Author)
                    .SingleOrDefault(t => t.Id.Equals(topic.Id));

                if (topicFromDb == null)
                    return RedirectToAction("Index", "Home");

                topicFromDb.Title = topic.Title;
                topicFromDb.Description = topic.Description;

                int categoryId = context.Categories.SingleOrDefault(c => c.Name == categoryName).Id;
                topicFromDb.CategoryId = categoryId;

                topicFromDb.LastUpdatedDate = DateTime.Now;

                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(topic);
        }
    }
}
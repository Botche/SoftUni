using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forum.Models;
using Forum.Data;
using Microsoft.EntityFrameworkCore;

namespace Forum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ForumDbContext context;

        public HomeController(ForumDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Category> categories = context.Categories
                .Include(c => c.Author)
                .Include(c => c.Topics)
                .ThenInclude(t => t.Author)
                .ToList();

            List<Topic> topics = context.Topics
                .Include(t => t.Author)
                .Include(x => x.Comments)
                .ThenInclude(c => c.Author)
                .OrderByDescending(x => x.CreatedDate)
                .ThenByDescending(x => x.LastUpdatedDate)
                .ToList();

            ViewData["Categories"] = categories;

            return View(topics);
        }
    }
}

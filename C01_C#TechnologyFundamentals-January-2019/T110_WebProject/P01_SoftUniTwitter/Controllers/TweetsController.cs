﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftUniTwitter.Data;
using SoftUniTwitter.Models;

namespace SoftUniTwitter.Controllers
{
    [Authorize]
    public class TweetsController : Controller
    {
        ApplicationDbContext db;

        public TweetsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Create()
        {
            var model = new List<TweetViewModel>();
            return View(model);
        }

        public IActionResult SaveToDatabase(string text)
        {
            var tweet = new Tweet
            {
                Text = text,
                CreatedOn = DateTime.Now,
                UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value
            };

            db.Tweets.Add(tweet);
            db.SaveChanges();

            return Redirect("/");
        }

        public IActionResult ByHashtag(string id)
        {
            var model = db.Tweets.Select(x =>
              new TweetViewModel
              {
                  CreatedOn = x.CreatedOn,
                  Text = x.Text,
                  Username = x.User.UserName
              }).OrderByDescending(x => x.CreatedOn)
              .Where(x => x.Text.Contains("#" + id))
              .ToList();

            return View(model);
        }
    }
}
using Lab4.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4.Controllers
{
    [Authorize]
    public class TweetController : Controller
    {
        public ActionResult Index()
        {
            return View("MainForm");
        }
        ApplicationDbContext db = ApplicationDbContext.Create();
        [HttpGet]
        public ActionResult TweetsList()
        {
            var tweets = db.Tweets.OrderByDescending(p => p.DateOfCreation).Take(20).ToList();
            return Json(tweets, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CreateTweet(Tweet tweet)
        {
            //var newTweet = new Tweet
            //{
            //    Content = Content,
            //    ApplicationUserId = User.Identity.GetUserId(),
            //    ApplicationUser = db.Users.Find(User.Identity.GetUserId()),
            //    DateOfCreation = DateTime.Now
            //};
            tweet.DateOfCreation = DateTime.Now;
            tweet.ApplicationUser = db.Users.Find(User.Identity.GetUserId());
            tweet.ApplicationUserId = User.Identity.GetUserId();
            db.Tweets.Add(tweet);
            db.SaveChanges();

            //return RedirectToAction("MainForm", "Tweet");
            return Json(tweet);
        }
    }
}
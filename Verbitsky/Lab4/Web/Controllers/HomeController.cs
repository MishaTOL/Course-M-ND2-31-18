using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        public HomeController(ApplicationDbContext context, UserManager<User> userManager, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var tweets = context.Tweets.Take(20).Include(a => a.Author).AsEnumerable();
            var tweetsView = mapper.Map<IEnumerable<Tweet>, IEnumerable<TweetViewModel>>(tweets);
            return View(tweetsView);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TweetViewModel tweetView)
        {
            var tweet = mapper.Map<TweetViewModel, Tweet>(tweetView);
            var user = await userManager.GetUserAsync(User);
            tweet.Author = user;
            context.Tweets.Add(tweet);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            var tweet = new Tweet() { Id = Id };
            context.Attach(tweet);
            context.Tweets.Remove(tweet);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            var tweet = context.Tweets.Find(Id);
            var tweetView = mapper.Map<Tweet, TweetViewModel>(tweet);
            return View(tweetView);
        }
        [HttpPost]
        public ActionResult Edit(TweetViewModel tweetView)
        {
            var tweet = mapper.Map<TweetViewModel, Tweet>(tweetView);
            context.Attach(tweet);
            var entry = context.Entry(tweet);
            entry.Property(e => e.Content).IsModified = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

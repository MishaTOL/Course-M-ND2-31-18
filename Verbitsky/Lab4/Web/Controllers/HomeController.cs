using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Contracts.Models;
using Data.Implementation.Models;
using Domain.Implementation.Service;
using DomainContracts.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<UserEntity> userManager;
        private readonly TweetService tweetService;
        public HomeController(ApplicationDbContext context, UserManager<UserEntity> userManager, IMapper mapper)
        {
            this.context = context;
            this.userManager = userManager;
            this.tweetService = new TweetService(context, mapper);
        }
        public IActionResult Index()
        {
            var tweets = tweetService.Get();
            return View(tweets);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TweetViewModel tweet)
        {
            var user = userManager.GetUserId(User);
            tweetService.Create(tweet, user);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            tweetService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var tweet = tweetService.GetsById(id);
            return View(tweet);
        }
        [HttpPost]
        public ActionResult Edit(TweetViewModel tweet)
        {
            tweetService.Edit(tweet);
            return RedirectToAction("Index");
        }


        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}

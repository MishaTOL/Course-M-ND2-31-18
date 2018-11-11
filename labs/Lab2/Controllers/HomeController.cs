using AutoMapper;
using Lab2.MyService.Domain.Core;
using Lab2.MyService.Domain.Interface;
using Lab2.MyService.Infrastructure.Data;
using Lab2.MyService.Infrastructure.ViewCRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Post> repo;

        public HomeController()
        {
            repo = new PostRepository();
        }



        public ActionResult Index()
        {
            var posts = repo.GetAll();


            //// Настройка AutoMapper
            //Mapper.Initialize(cfg => cfg.CreateMap<Post, IndexViewPost>());
            //// сопоставление
            //List<IndexViewPost> posts =
            //    Mapper.Map<IEnumerable<Post>, List<IndexViewPost>>(repo.GetAll());
            return View(posts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
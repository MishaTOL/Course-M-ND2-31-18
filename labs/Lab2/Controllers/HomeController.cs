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
            Mapper.Initialize(cfg => cfg.CreateMap<Post, ViewPost>());
        }



        public ActionResult Index()
        {
            //// Настройка AutoMapper
            
            //// сопоставление
            var posts =
                Mapper.Map<IEnumerable<Post>, List<ViewPost>>(repo.GetAll());
            return View(posts);
        }

        public ActionResult Create()
        {
            Post post = new Post() { Author="Ivanov", Created = DateTime.Now, Content="New Content" };

            return View(post);
        }
        [HttpPost]
        public ActionResult Create(Post model)
        {
            if (ModelState.IsValid)
            {
                // Настройка AutoMapper
                //Mapper.Initialize(cfg => cfg.CreateMap<CreatPost, Post>());
                // Выполняем сопоставление
                //Post post = Mapper.Map<CreatPost, Post>(model);
                repo.Create(model);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Post post = repo.Get(id.Value);
            // Настройка AutoMapper
            //Mapper.Initialize(cfg => cfg.CreateMap<Post, EditPost>());
            // Выполняем сопоставление
            //EditPost post = Mapper.Map<Post, EditPost>(repo.Get(id.Value));
            return View(post);
        }
        [HttpPost]
        public ActionResult Edit(Post model)
        {
            if (ModelState.IsValid)
            {
                // Настройка AutoMapper
                //Mapper.Initialize(cfg => cfg.CreateMap<Post, EditPost>());
                //// Выполняем сопоставление
                //Post post = Mapper.Map<EditPost, Post>(model);
                repo.Update(model);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(model);
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
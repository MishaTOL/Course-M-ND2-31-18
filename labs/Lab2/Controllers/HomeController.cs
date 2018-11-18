using AutoMapper;
using Lab2.Models;
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
        IRepository<Post> repository = new PostRepository();



        public ActionResult Index()
        {
            IEnumerable<Post> posts = repository.GetAll();

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

                repository.Create(model);
                repository.Save();

                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Post post = repository.Get(id.Value);

            return View(post);
        }
        [HttpPost]
        public ActionResult Edit(Post model)
        {
            if (ModelState.IsValid)
            {

                repository.Update(model);
                repository.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Post post = repository.Get(id.Value);

            return View(post);


        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Post post = repository.Get(id.Value);

            return View(post);
        }
        [HttpPost]
        public ActionResult Delete(Post model)
        {
            if (ModelState.IsValid)
            {

                repository.Delete(model.Id);
                repository.Save();
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
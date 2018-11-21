using AutoMapper;
using Lab2.Models;
using Lab2.Models.db;
using Lab2.MyService.Domain.Interface;
using Lab2.MyService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Postdb> repository = new PostDbRepository();
        ICommentDbRepository<Commentdb> repositoryComment = new CommentDbRepository();
        // GET: Home
        public ActionResult Index()
        {
            var posts = Mapper.Map<IEnumerable<Postdb>, IEnumerable<Post>>(repository.GetAll());
            return View(posts);
        }
        public ActionResult CreatePost()
        {
            Postdb post = new Postdb() { Id = 1, StudentId = 1, Content = "New Content", Created = DateTime.Now };

            return View(post);
        }
        [HttpPost]
        public ActionResult CreatePost(Postdb model)
        {
            if (ModelState.IsValid)
            {
                model.Created = DateTime.Now;
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
            Postdb post = repository.Get(id.Value);

            return View(post);
        }
        [HttpPost]
        public ActionResult Edit(Postdb model)
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
            Postdb postdb = repository.Get(id.Value);
            var post = Mapper.Map<Postdb, Post>(postdb);

            return View(post);


        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Postdb post = repository.Get(id.Value);

            return View(post);
        }
        [HttpPost]
        public ActionResult Delete(Postdb model)
        {
            if (ModelState.IsValid)
            {

                repository.Delete(model.Id);
                repository.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult CreateComment()
        {
            Commentdb commentdb = new Commentdb() { StudentId=1, Created=DateTime.Now };
            return View(commentdb);
        }
        [HttpPost]
        public ActionResult CreateComment(Commentdb model)
        {
            if (ModelState.IsValid)
            {
                model.Created = DateTime.Now;
                repositoryComment.Create(model);
                repositoryComment.Save();

                return RedirectToAction("Details");
            }
            return View(model);
        }
    }

}
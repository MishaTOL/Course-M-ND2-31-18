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
        IStudentDbRepository<Studentdb> repositoryStudent = new StudentDbRepository();

        // GET: Home
        public ActionResult Index()
        {
            if (null == Session["StudentId"])
            {
                ModelState.AddModelError("", "Вы не авторизованы");
                return RedirectToAction("Login");
            }
            else
            {
                int id;
                int.TryParse(Session["StudentId"].ToString(), out id);
                Studentdb student = repositoryStudent.Get(id);
                ModelState.AddModelError("", $"Ваш пользователь: {student.FirstName} {student.LastName}");
            }

            //
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

        public ActionResult Details(int id)
        {
            Postdb postdb = repository.Get(id);
            var post = Mapper.Map<Postdb, Post>(postdb);
            Session["PostId"] = post.Id;
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
            Commentdb commentdb = new Commentdb() {  };
            return View(commentdb);
        }
        [HttpPost]
        public ActionResult CreateComment(Commentdb model)
        {
            if (ModelState.IsValid)
            {
                model.Created = DateTime.Now;
                //
                int Studentid;
                int.TryParse(Session["StudentId"].ToString(), out Studentid);
                model.StudentId = Studentid;
                //
                int PostId;
                int.TryParse(Session["PostId"].ToString(), out PostId);
                model.PostId = PostId;
                //
                model.Created = DateTime.Now;
                //
                repositoryComment.Create(model);
                repositoryComment.Save();
                
                return RedirectToAction("Details", new { id = model.PostId});
            }
            return View(model);
        }

        public ActionResult Login()
        {

            ModelState.AddModelError("", "Вы не авторизованы");

            Studentdb studentdb = new Studentdb() { FirstName = "Alex", LastName = "M" };
            return View(studentdb);
        }
        [HttpPost]
        public ActionResult Login(Studentdb model)
        {
            if (ModelState.IsValid)
            {
                Studentdb student = repositoryStudent.Get(model);
                if (student == null)
                {
                    repositoryStudent.Create(model);
                    repositoryStudent.Save();
                    Studentdb ss = repositoryStudent.Get(model);
                    Session["StudentId"] = ss.Id;
                }
                else
                {
                    Session["StudentId"] = student.Id.ToString();
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }

}
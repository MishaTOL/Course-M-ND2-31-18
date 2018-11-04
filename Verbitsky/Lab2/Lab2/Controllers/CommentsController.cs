using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2.Models;

namespace Lab2.Controllers
{
    public class CommentsController : Controller
    {
        private NewsStudentDbContext db = new NewsStudentDbContext();
        public ActionResult Create(int Post_Id)
        {
            Session["Post_Id"] = Post_Id;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Comment comment)
        {            
            comment.AuthorId = ((Student)Session["User"]).Id;
            comment.PostId = (int)Session["Post_Id"];
            db.Comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("Details", "Posts", new { id = (int)Session["Post_Id"] });
        }
        public ActionResult Edit(int id)
        {
            return View(db.Comments.Where(a => a.Id == id).SingleOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(Comment comment)
        {
            db.Comments.Add(comment);
            db.Entry(comment).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Details", "Posts", new { id = comment.PostId });
        }
        public ActionResult Delete(int id, int id_Post)
        {
            var comment = new Comment { Id = id };
            db.Comments.Attach(comment);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Details", "Posts", new { id = id_Post });
        }
    }
}
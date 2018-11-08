using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2.Models;
using Lab2.Models.ViewModels.Comments;
using Lab2.Models.ViewModels.Posts;
using AutoMapper;

namespace Lab2.Controllers
{
    public class CommentsController : Controller
    {
        private NewsStudentDbContext db;
        public CommentsController()
        {
            db = new NewsStudentDbContext();
        }
        public ActionResult Create(int postId)
        {
            return View(new CreateCommentViewModel() { PostId = postId });
        }
        [HttpPost]
        public ActionResult Create(CreateCommentViewModel _comment)
        {
            var comment = Mapper.Map<CreateCommentViewModel, Comment>(_comment);
            comment.AuthorId = ((Student)Session["User"]).Id;
            db.Comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("Details", "Posts", new { id = _comment.PostId });
        }
        public ActionResult Edit(int id)
        {
            var comment = Mapper.Map<Comment, EditCommentViewModel>(db.Comments.Where(a => a.Id == id).SingleOrDefault());
            return View(comment);
        }
        [HttpPost]
        public ActionResult Edit(EditCommentViewModel _comment)
        {
            var comment = Mapper.Map<EditCommentViewModel, Comment>(_comment);
            db.Comments.Add(comment);
            db.Entry(comment).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Details", "Posts", new { id = comment.PostId });
        }
        public ActionResult Delete(int id, int PostId)
        {
            var comment = new Comment { Id = id };
            db.Comments.Attach(comment);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Details", "Posts", new { id = PostId });
        }
    }
}
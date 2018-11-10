using Lab2.Domain.Contracts;
using Lab2.Domain.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class CommentController : Controller
    {
        private CommentService service;
        public CommentController()
        {
            service = new CommentService();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CommentViewModel comment)
        {
            try
            {
                comment.AuthorId = int.Parse(Session["StudentId"].ToString());
                comment.Created = DateTime.Now;
                comment.PostId = int.Parse(Session["PostId"].ToString());
                service.CreateComment(comment);
                return RedirectToAction("Index", "Post");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            PostService postService = new PostService();
            var post = postService.GetPostById(id);
            var model = service.GetPostComments(post);
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = service.GetCommentById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                service.DeleteComment(id);
                return RedirectToAction("Index", "Post");
            }
            catch (Exception exception)
            {
                return View();
            }
        }
    }
}
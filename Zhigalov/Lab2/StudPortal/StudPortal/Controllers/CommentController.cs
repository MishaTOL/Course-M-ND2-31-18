using Service.Services;
using ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudPortal.Controllers
{
    public class CommentController : Controller
    {
        StudentService studentService;
        PostService postService;
        CommentService commentService;

        public CommentController()
        {
            studentService = new StudentService();
            postService = new PostService();
            commentService = new CommentService();
        }


        public ActionResult CreateComment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateComment(CommentInfo comment, int user, int post)
        {
            TempData["user"] = user;
            TempData["post"] = post;

            comment.AuthorId = studentService.GetById(user).Id;     // maybe 'user' from parameters better?
            comment.PostId = postService.GetById(post).Id;          // maybe 'post' from parameters better?
            commentService.Create(comment);
            return RedirectToAction("GetPost", "Post", new { user = TempData["user"], post = TempData["post"] });
        }

        public ActionResult DeleteComment(int user, int post, int comment)
        {
            TempData["user"] = user;
            TempData["post"] = post;
            var currentComment = commentService.GetAll().Where(x => x.Id == comment).FirstOrDefault();
            if (currentComment.AuthorId == user)
            {
                commentService.Delete(comment);
            }
            return RedirectToAction("GetPost", "Post", new { user = TempData["user"], post = TempData["post"] });
        }

        public ActionResult EditComment(int user, int post, int comment)
        {
            TempData["user"] = user;
            TempData["post"] = post;
            TempData["comment"] = comment;
            var currentComment = commentService.GetAll().Where(x => x.Id == comment).FirstOrDefault();
            if (currentComment.AuthorId == user)
            {
                return View(currentComment);
            }
            return RedirectToAction("GetPost", "Post", new { user = TempData["user"], post = TempData["post"] });
        }

        [HttpPost]
        public ActionResult EditComment(CommentInfo commentTemp, int user, int post, int comment)
        {
            TempData["user"] = user;
            TempData["post"] = post;

            commentService.Edit(commentTemp);
            return RedirectToAction("GetPost", "Post", new { user = TempData["user"], post = TempData["post"] });
        }
    }
}
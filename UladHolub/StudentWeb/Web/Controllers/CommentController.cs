using Domain.Contracts.Repositories;
using Domain.Contracts.ViewModel;
using System;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CommentController : Controller
    {
        private IService studentService;

        public CommentController(IService service)
        {
            studentService = service;
        }

        [HttpGet]
        public ActionResult Create(int? studentId, int? postId)
        {
            if (studentId == null || studentId <= 0) { return RedirectToAction("Registration", "Student"); }
            if (postId == null || postId <= 0) { return RedirectToAction("ShowList", "Post", new { id = studentId }); }
            var student = studentService.GetStudent((int)studentId);
            if (student == null) { return RedirectToAction("Registration", "Student"); }
            var post = studentService.GetPost((int)postId);
            if (post == null) { return RedirectToAction("ShowList", "Post", new { id = studentId }); }
            return View(new Tuple<StudentViewModel, PostViewModel, CommentViewModel>
                (student, post, new CommentViewModel() {AuthorId = studentId, PostId = postId }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int studentId, int postId, [Bind(Prefix = "Item3")] CommentViewModel comment)
        {
            studentService.CreateComment(comment);
            return RedirectToAction("Show", "Post", new { studentId = studentId, postId = postId });
        }

        [HttpGet]
        public ActionResult Redact(int? studentId, int? commentId)
        {
            if (studentId == null || studentId <= 0) { return RedirectToAction("Registration", "Student"); }
            if (commentId == null || commentId <= 0) { return RedirectToAction("ShowList", "Post", new { id = studentId }); }
            var student = studentService.GetStudent((int)studentId);
            if (student == null) { return RedirectToAction("Registration", "Student"); }
            var comment = studentService.GetComment((int)commentId);
            if (comment == null) { return RedirectToAction("ShowList", "Post", new { id = studentId }); }
            return View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Redact(CommentViewModel comment)
        {
            studentService.UpdateComment(comment);
            return RedirectToAction("Show", "Post", new { studentId = comment.AuthorId, postId = comment.PostId });
        }

        [HttpGet]
        public ActionResult Delete(int? studentId, int? postId, int? commentId)
        {
            studentService.DeleteComment((int)commentId);
            return RedirectToAction("Show", "Post", new { studentId = studentId, postId = postId });
        }
    }
}
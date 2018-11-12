using Domain.Contracts.Repositories;
using Domain.Contracts.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class PostController : Controller
    {
        private IService studentService;

        public PostController(IService service)
        {
            studentService = service;
        }

        [HttpGet]
        public ActionResult ShowList(int? id)
        {
            if (id == null || id <= 0) { return RedirectToAction("Registration", "Student"); }
            var student = studentService.GetStudent((int)id);
            if (student == null) { return RedirectToAction("Registration", "Student"); }
            var posts = studentService.GetAllPosts();
            return View(new Tuple<StudentViewModel, IEnumerable<PostViewModel>>(student,posts));
        }

        [HttpGet]
        public ActionResult Show(int? studentId, int? postId)
        {
            if (studentId == null || studentId <= 0) { return RedirectToAction("Registration", "Student"); }
            if (postId == null || postId <= 0) { return RedirectToAction("ShowList", "Post", new {id = studentId }); }
            var student = studentService.GetStudent((int)studentId);
            if (student == null) { return RedirectToAction("Registration", "Student"); }
            var post = studentService.GetPost((int)postId);
            if (post == null) { return RedirectToAction("ShowList", "Post", new { id = studentId }); }
            return View(new Tuple<StudentViewModel, PostViewModel>(student, post));
        }

        [HttpGet]
        public ActionResult Delete(int? studentId, int? postId)
        {
            studentService.DeletePost((int)postId);
            return RedirectToAction("ShowList", "Post", new { id = studentId });
        }

        [HttpGet]
        public ActionResult Redact(int? studentId, int? postId)
        {
            if (studentId == null || studentId <= 0) { return RedirectToAction("Registration", "Student"); }
            if (postId == null || postId <= 0) { return RedirectToAction("ShowList", "Post", new { id = studentId }); }
            var student = studentService.GetStudent((int)studentId);
            if (student == null) { return RedirectToAction("Registration", "Student"); }
            var post = studentService.GetPost((int)postId);
            if (post == null) { return RedirectToAction("ShowList", "Post", new { id = studentId }); }
            return View(new Tuple<StudentViewModel, PostViewModel>(student,post));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Redact(int id, string tagString, [Bind(Prefix = "Item2")] PostViewModel post)
        {
            studentService.UpdatePost(post, tagString);
            return RedirectToAction("ShowList", "Post", new { id = id });
        }

        [HttpGet]
        public ActionResult Create(int? id)
        {
            if (id == null || id <= 0) { return RedirectToAction("Registration", "Student"); }
            var student = studentService.GetStudent((int)id);
            if (student == null) { return RedirectToAction("Registration", "Student"); }
            return View(new Tuple<StudentViewModel, PostViewModel>(student, new PostViewModel()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, string tagString, [Bind(Prefix = "Item2")] PostViewModel post)
        {
            studentService.CreatePost(post, tagString);
            return RedirectToAction("ShowList", "Post", new { id = id });
        }
    }
}
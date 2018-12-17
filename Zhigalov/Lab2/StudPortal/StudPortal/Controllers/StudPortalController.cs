using Service.Services;
using ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudPortal.Controllers
{
    public class StudPortalController : Controller
    {
        StudentService studentService;
        PostService postService;

        public StudPortalController()
        {
            studentService = new StudentService();
            postService = new PostService();
        }

        // GET: StudPortal
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(StudentInfo student)
        {
            var currentStudent = studentService.CreateAndGet(student);
            return RedirectToAction("NewsFeed", new { user = currentStudent.Id });
        }

        public ActionResult NewsFeed(int user)
        {
            TempData["user"] = user;
            var posts = postService.GetAll();
            return View(posts);
        }
    }
}
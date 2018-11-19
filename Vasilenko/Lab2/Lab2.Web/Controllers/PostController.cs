using AutoMapper;
using Lab2.Business.Abstraction;
using Lab2.Business.Abstraction.Entity;
using Lab2.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        public ActionResult Posts(int studentId)
        {
            var posts = postService.GetPosts(studentId);
            List<PostViewModel> listPosts = Mapper.Map<List<Post>, List<PostViewModel>>(posts);
            ViewBag.StudentId = studentId;
            return View(listPosts);
        }

        [HttpGet]
        public ActionResult Add(int studentId)
        {
            ViewBag.StudentId = studentId;
            return View();
        }

        [HttpPost]
        public ActionResult Add(PostViewModel post, int studentId)
        {
            Post postMap = Mapper.Map<PostViewModel, Post>(post);
            postService.AddPost(postMap, studentId);
            return RedirectToAction("Posts", "Post", new { studentId = studentId });
        }
        [HttpGet]
        public ActionResult Update(int postId)
        {
            var update = postService.FindPost(postId);
            return View(update);
        }
        [HttpPost]
        public ActionResult Update(PostViewModel post)
        {
            Post postMap = Mapper.Map<PostViewModel, Post>(post);
            postService.UpdatePost(postMap);
            return RedirectToAction("Posts", "Post", new { studentId = post.Author.Id });
        }

        public ActionResult Remove(int postId)
        {
            var post = postService.DeletePost(postId);
            return RedirectToAction("Posts", "Post", new { studentId = post });
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            ViewBag.PostId = id;
            var post = postService.FindPost(id);
            PostViewModel postMap = Mapper.Map<Post, PostViewModel>(post);
            return View(postMap);
        }

    }
}
 
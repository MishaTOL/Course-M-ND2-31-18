using Lab2.Domain.Contracts;
using Lab2.Domain.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class PostController : Controller
    {
        private PostService service;

        public PostController()
        {
            service = new PostService();
        }
        // GET: Post
        public ActionResult Index()
        {
            try
            {
                var posts = service.GetPosts();
                return View(posts);
            }
            catch
            {
                return RedirectToAction("Index", "Student");
            }
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(PostViewModel post)
        {
            try
            {
                // TODO: Add insert logic here
                post.AuthorId = int.Parse(Session["StudentId"].ToString());
                post.Created = DateTime.Now;
                service.CreatePost(post);

                var newPost = service.GetPosts().Where(t => t.Content == post.Content).SingleOrDefault();
                TagService tagService = new TagService();
                tagService.AddTags(newPost.PostId, Request.Form["Tags"]);

                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            var post = service.GetPostById(id);
            return View(post);
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var model = service.GetPostById(id);
                model.Content = Request.Form["Content"];
                service.EditPost(model);

                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            var post = service.GetPostById(id);
            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                service.DeletePost(id);

                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }
    }
}

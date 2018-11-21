using Domain.Contracts.Models;
using Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class TagController : Controller
    {
        private readonly IService<TagView> tagService;
        private readonly IService<PostView> postService;

        public TagController(IService<TagView> tagService, IService<PostView> postService)
        {
            this.tagService = tagService;
            this.postService = postService;
        }

        // GET: Tag/Create
        public ActionResult Create(int? postId)
        {
            ViewBag.PostId = postId;
            return View(new TagView());
        }

        // POST: Tag/Create
        [HttpPost]
        public ActionResult Create(TagView tag, int postId)
        {
            try
            {
                var post = postService.GetById(postId);
                if (post == null)
                {
                    return View("Error");
                }

                var existingTag = tagService.GetAll()
                    .FirstOrDefault(t => t.Name == tag.Name);

                if (existingTag == null)
                {
                    existingTag = tagService.Add(tag);
                }

                existingTag.Posts.Add(post);
                tagService.Update(existingTag);

                return RedirectToAction("Edit", "Post", new { id = postId });
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Tag/Delete/5
        public ActionResult Delete(int id)
        {
            tagService.Delete(id);
            return RedirectToAction("Index", "Post");
        }

    }
}

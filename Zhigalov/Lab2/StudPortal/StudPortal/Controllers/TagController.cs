using Service.Services;
using ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudPortal.Controllers
{
    public class TagController : Controller
    {
        TagService tagService;
        TagPostMapService tagPostService;
        TagPostMapInfo tagPost;

        public TagController()
        {
            tagService = new TagService();
            tagPostService = new TagPostMapService();
            tagPost = new TagPostMapInfo();
        }

        public ActionResult CreateTag(int user, int post)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTag(TagInfo tag, int user, int post)
        {
            int userId = user;

            tagPost.PostId = post;
            tagService.Create(tag);
            tagPost.TagId = tagService.GetAll().Where(x => x.Name == tag.Name).FirstOrDefault().Id;
            tagPostService.Create(tagPost);

            return RedirectToAction("NewsFeed", "StudPortal", new { user = userId });
        }
    }
}
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
    public class TagController:Controller
    {
        private readonly ITagService tagService;

        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }

        [HttpGet]
        public ActionResult AddTag(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTag(TagViewModel tag, int id)
        {
            if (tag.Name != null)
            {
                Tag tagMap = Mapper.Map<TagViewModel, Tag>(tag);
                tagService.AddTag(id, tagMap);
                return RedirectToAction("Details", "Post", new { id = id });
            }
            else
            {
                return RedirectToAction("Details", "Post", new { id = id });
            }
        }

        public ActionResult GetTags(int id)
        {
            var tags = tagService.GetTags(id);
            List<TagViewModel> tagsMap = Mapper.Map<List<Tag>, List<TagViewModel>>(tags);
            return View(tagsMap);
        }

    public ActionResult Delete(int id, int postId)
        {
            tagService.DeleteTag(id,postId);
            return RedirectToAction("Details", "Post", new { id = postId });
        }
    }
}
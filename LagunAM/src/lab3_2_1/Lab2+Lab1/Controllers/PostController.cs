using AutoMapper;
using DBModels.Models;
using DBRepConUow.UnitOfWork;
using Lab2_Lab1.InfoModels;
using Lab2_Lab1.Services;
using Lab2_Lab1.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2_Lab1.Controllers
{
    public class PostController : Controller
    {
        private IService<Post> postService;
        public PostController(IService<Post> postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        public JsonResult CheckDuplicateString(string TagsString)
        {
            List<string> Tags = TagsString.Split(' ').ToList();
            HashSet<string> hashSet = new HashSet<string>();
            foreach (string Now in Tags)
            {
                if (!hashSet.Add(Now))
                    return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet); ;
        }

        [HttpGet]
        public ActionResult Add(PostInfo postInfo)
        {
            return View(Mapper.Map<PostInfo, AddView>(postInfo));
        }

        [HttpPost]
        public ActionResult Add(AddView addView)
        {
            if (ModelState.IsValid)
            {
                ((PostService)(postService)).Add(
                    Mapper.Map<AddView, PostInfo>(addView));
                return RedirectToAction("Index", "Post",
                    Mapper.Map<AddView, PostInfo>(addView));                
            }
            return View(addView);
        }

        [HttpGet]
        public ActionResult Edit(PostInfo postInfo)
        {
            return 
                View(Mapper.Map<PostInfo, EditView>(postInfo));
        }

        [HttpPost]
        public ActionResult Edit(EditView editView)
        {
            if (ModelState.IsValid)
            {
                PostInfo postInfo = Mapper.Map<EditView, PostInfo>(editView);
                ((PostService)(postService)).Edit(postInfo);
                return RedirectToAction("Index", "Post", postInfo);
            }
            return View(editView);
        }

        [HttpGet]
        public ActionResult Index(PostInfo postInfo)
        {
            var indexView = Mapper.Map<PostInfo, IndexView>(postInfo);
            indexView.Posts = ((PostService)(postService)).GetPosts();
            return View(indexView);
        }

        [HttpGet]
        public ActionResult Delete(PostInfo postInfo)
        {
            ((PostService)(postService)).Remove(postInfo);
            return RedirectToAction("Index", "Post", postInfo);
        }
            
    }
}
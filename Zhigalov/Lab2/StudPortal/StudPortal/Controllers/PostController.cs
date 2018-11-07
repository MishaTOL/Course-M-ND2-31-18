using Service.Services;
using ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudPortal.Controllers
{
    public class PostController : Controller
    {
        StudentService studentService;
        PostService postService;
        CommentService commentService;
        TagService tagService;
        TagPostMapService tagPostService;

        public PostController()
        {
            studentService = new StudentService();
            postService = new PostService();
            commentService = new CommentService();
            tagService = new TagService();
            tagPostService = new TagPostMapService();
        }

        public ActionResult CreatePost(int user)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost(PostInfo post, int user)
        {
            post.AuthorId = studentService.GetById(user).Id;
            postService.Create(post);
            TempData["post"] = postService.GetAll().Last().Id;
            return RedirectToAction("CreateTag", "Tag", new { user = post.AuthorId, post = TempData["post"] });
        }

        public ActionResult GetPost(int user, int post)
        {
            TempData["user"] = user;
            TempData["post"] = post;

            var currentPost = postService.GetById(post);
            currentPost.Tags = tagPostService.GetAll().Where(x => x.PostId == currentPost.Id);
            foreach (var tag in currentPost.Tags)
            {
                tag.Tag = tagService.GetAll().Where(x => x.Id == tag.TagId).FirstOrDefault();
            }

            currentPost.Author = studentService.GetById(currentPost.AuthorId);
            currentPost.Comments = commentService.GetAll().Where(x => x.PostId == post);
            foreach (var comment in currentPost.Comments)
            {
                comment.Author = studentService.GetAll().Where(x => x.Id == comment.AuthorId).FirstOrDefault();
            }
            return View(currentPost);
        }

        public ActionResult DeletePost(int user, int post)
        {
            TempData["user"] = user;
            var currentPost = postService.GetById(post);

            if (currentPost.AuthorId == user)
            {
                var currentPostComments = commentService.GetAll().Where(x => x.PostId == currentPost.Id);
                foreach (var comment in currentPostComments)
                {
                    commentService.Delete(comment.Id);
                }

                var currentTagPostMaps = tagPostService.GetAll().Where(x => x.PostId == currentPost.Id);
                foreach (var tagPost in currentTagPostMaps)
                {
                    tagPostService.Delete(tagPost.Id);
                }

                postService.Delete(post);
            }
            return RedirectToAction("NewsFeed", "StudPortal", new { user = TempData["user"] });
        }

        public ActionResult EditPost(int user, int post)
        {
            TempData["user"] = user;
            var currentPost = postService.GetById(post);
            if (currentPost.AuthorId == user)
            {
                return View(currentPost);
            }
            return RedirectToAction("NewsFeed", "StudPortal", new { user = TempData["user"] });
        }

        [HttpPost]
        public ActionResult EditPost(PostInfo postTemp, int user, int post)
        {
            TempData["user"] = user;
            TempData["post"] = post;
            postService.Edit(postTemp);
            return RedirectToAction("NewsFeed", "StudPortal", new { user = TempData["user"] });
        }
    }
}
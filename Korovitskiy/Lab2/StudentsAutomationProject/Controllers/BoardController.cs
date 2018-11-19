using PresentationModel;
using Students.ServicesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsAutomationProject.Controllers
{
    public class BoardController : Controller
    {
        IInfoModelService<PostInfo> postService = new Students.Services.Services.PostsService();
        IInfoModelService<CommentInfo> commentService = new Students.Services.Services.CommentsService();
        // GET: Board
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult OnBoard()
        {
            IEnumerable<PostInfo> posts = postService.GetModelCollections();
            return View(AutoMapper.Mapper.Map<IEnumerable<PostInfo>, IEnumerable<PostViewModel>>(posts));
        }

        [HttpPost]
        public ActionResult CreatePost(PostViewModel post)
        {
            post.CreatedDate = DateTime.Now;
            post.StudentId = 1;
            postService.Create(AutoMapper.Mapper.Map<PostViewModel, PostInfo>(post));
            return RedirectToAction("OnBoard");
        }

        [HttpGet]
        public ActionResult Post(int id)
        {
            var post = postService.GetModelById(id);
            return View(AutoMapper.Mapper.Map<PostInfo, PostViewModel>(post));
        }

        [HttpPost]
        public ActionResult UpdatePost(PostViewModel post)
        {
            var servicePost = postService.GetModelById(post.Id);
            servicePost.Content = post.Content;
            postService.Update(servicePost);
            return new HttpStatusCodeResult(200);
        }

        [HttpPost]
        public ActionResult CreateComment(CommentViewModel comment)
        {
            comment.StudentId = 1;
            comment.CreatedDate = DateTime.Now;
            var serviceModel = AutoMapper.Mapper.Map<CommentViewModel, CommentInfo>(comment);
            commentService.Create(serviceModel);
            return RedirectToAction("Post", new { id = comment.PostId });
        }

        [HttpPost]
        public ActionResult UpdateComment(CommentViewModel comment)
        {
            var servicePost = commentService.GetModelById(comment.Id);
            servicePost.Content = comment.Content;
            commentService.Update(servicePost);
            return new HttpStatusCodeResult(200);
        }

        [HttpPost]
        public ActionResult DeletePost(int id)
        {
            postService.Delete(id);
            return new HttpStatusCodeResult(200);//RedirectToAction("OnBoard", "Board");
        }

        [HttpPost]
        public ActionResult DeleteComment(int id)
        {
            commentService.Delete(id);
            return new HttpStatusCodeResult(200);
        }
    }
}
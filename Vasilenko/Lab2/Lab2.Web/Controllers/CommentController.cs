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
    public class CommentController:Controller
    {
        private readonly ICommentService commentService;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet]
        public ActionResult AddComment(int postId, int studentId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddComment(CommentViewModel comment, int id)
        {
            Comment commentMap = Mapper.Map<CommentViewModel, Comment>(comment);
            if (comment.Content != null)
            {
                commentService.AddComment(commentMap, id);
                return RedirectToAction("Details", "Post", new { id = id });
            }
            else
            {
                return RedirectToAction("Details", "Post", new { id = id });
            }
        }

        public ActionResult GetComments(int postId)
        {
            var comments = commentService.GetComments(postId);
            List<CommentViewModel> commentsMap = Mapper.Map<List<Comment>, List<CommentViewModel>>(comments);
            return View(commentsMap);
        }
    }
}
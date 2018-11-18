using AutoMapper;
using Lab2_Lab1.InfoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2_Lab1.ViewModels.Comment;
using Lab2_Lab1.Services;
using DBModels.Models;
using DBRepConUow.UnitOfWork;

namespace Lab2_Lab1.Controllers
{
    public class CommentController : Controller
    {
        private IService<Comment> commentService;

        public CommentController(IService<Comment> commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet]
        public ActionResult Index(CommentInfo commentInfo)
        {
            var indexView = Mapper.Map<CommentInfo, IndexView>(commentInfo);
            indexView.Comments = ((CommentService)(commentService)).GetComments(commentInfo);
            return View(indexView);
        }

        [HttpGet]
        public ActionResult Add(CommentInfo commentInfo)
        {
            var addEditView = Mapper.Map<CommentInfo, AddEditView>(commentInfo);
            return View(addEditView);
        }

        [HttpPost]
        public ActionResult Add(AddEditView addEditView)
        {
            var commentInfo = Mapper.Map<AddEditView, CommentInfo>(addEditView);
            ((CommentService)(commentService)).Add(commentInfo);
            return RedirectToAction("index", ((CommentService)(commentService)).GetPost(commentInfo));
        }

        [HttpGet]
        public ActionResult Edit(CommentInfo commentInfo)
        {
            var addEditView = Mapper.Map<CommentInfo, AddEditView>(commentInfo);
            return View(addEditView);
        }

        [HttpPost]
        public ActionResult Edit(AddEditView addEditView)
        {
            var commentInfo = Mapper.Map<AddEditView, CommentInfo>(addEditView);
            ((CommentService)(commentService)).Edit(commentInfo);
            return RedirectToAction("index", ((CommentService)(commentService)).GetPost(commentInfo));
        }
        [HttpGet]
        public ActionResult Delete(AddEditView addEditView)
        {
            var commentInfo = Mapper.Map<AddEditView, CommentInfo>(addEditView);
            ((CommentService)(commentService)).DeleteById(commentInfo);
            return RedirectToAction("index", ((CommentService)(commentService)).GetPost(commentInfo));
        }
    }
}
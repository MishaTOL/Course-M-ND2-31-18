using AutoMapper;
using Laba2.BusinessLogicLayer.DataTransferObject;
using Laba2.BusinessLogicLayer.Services;
using Laba2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laba2.Controllers
{
    public class CommentController : Controller
    {
        private int studentId;
        IMapper mapperModel;
        private OrderService orderService;

        public CommentController()
        {
            orderService = new OrderService();
            mapperModel = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CommentModel, CommentDTO>();
                cfg.CreateMap<CommentDTO, CommentModel>();
            }).CreateMapper();
        }
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int postId)
        {
            ReaderUser();
            return View(new CommentModel { StudentId = studentId,PostId=postId });
        }
        [HttpPost]
        public ActionResult Create(CommentModel comment)
        {
            orderService.ServiceComment.Insert(mapperModel.Map<CommentModel, CommentDTO>(comment));
            return RedirectToAction("Details", "Post", new { postId = comment.PostId });
        }

        private void ReaderUser()
        {
            string ss = (Session["StudentId"] ?? "0").ToString();
            int.TryParse(ss, out studentId);
        }
    }
}
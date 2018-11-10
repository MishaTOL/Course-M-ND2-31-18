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

    public class PostController : Controller
    {
        private int studentId;
        IMapper mapperPostModel;
        private OrderService orderService;

        public PostController()
        {
            orderService = new OrderService();
            mapperPostModel = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PostDTO, PostModel>();
                cfg.CreateMap<PostModel, PostDTO>();
                cfg.CreateMap<CommentDTO, CommentModel>();
            }).CreateMapper();
        }

        // GET: Post
        public ActionResult Index()
        {
            ReaderUser();
            if (studentId == 0)
                return RedirectToAction("Index", "Student");
            IEnumerable<PostModel> listPost = mapperPostModel.Map<IEnumerable<PostDTO>, IEnumerable<PostModel>>(orderService.ServicePost.GetPostes(studentId));
            return View(listPost);
        }

        public ActionResult Create()
        {
            ReaderUser();
            if (studentId == 0)
                return RedirectToAction("Index", "Student");
            return View(new PostModel { StudentId = studentId });
        }
        [HttpPost]
        public ActionResult Create(PostModel post)
        {
            orderService.ServicePost.Insert(mapperPostModel.Map<PostModel, PostDTO>(post));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int postId)
        {
            PostModel record = mapperPostModel.Map<PostDTO, PostModel>(orderService.ServicePost.GetPost(postId));
            return View(record);
        }

        public ActionResult Delete(int postId)
        {
            orderService.ServicePost.Delete(postId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(PostModel post)
        {
            orderService.ServicePost.Update(mapperPostModel.Map<PostModel, PostDTO>(post));
            return RedirectToAction("Index");
        }

        public ActionResult Details(int postId)
        {
            PostModel record = mapperPostModel.Map<PostDTO, PostModel>(orderService.ServicePost.GetPost(postId));
            record.CommentModels = mapperPostModel.Map<IEnumerable<CommentDTO>, IEnumerable<CommentModel>>(orderService.ServiceComment.GetComments(postId));
            return View(record);
        }

        private void ReaderUser()
        {
            string ss = (Session["StudentId"] ?? "0").ToString();
            int.TryParse(ss, out studentId);
        }
    }
}
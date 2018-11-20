using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2.Models;
using Lab2.Models.ViewModels.Posts;
using AutoMapper;

namespace Lab2.Controllers
{
    public class PostsController : Controller
    {
        private NewsStudentDbContext db;
        public PostsController()
        {
            db = new NewsStudentDbContext();
        }
        public ActionResult Index()
        {
            var posts = Mapper.Map<IEnumerable<Post>, IEnumerable<IndexPostViewModel>>(db.Posts.ToList());
            return View(posts);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreatePostViewModel postView)
        {
            string tags = postView.Tags;
            var post = Mapper.Map<CreatePostViewModel, Post>(postView);
            post.AuthorId = ((Student)Session["User"]).Id;
            db.Posts.Add(post);
            post.Created = DateTime.Now;
            if(post.Tags == null)
            {
                post.Tags = new List<Tags>();
            }
            foreach (var tag in tags.Split(' ').Distinct())
            {
                var buf = db.Tags.Where(a => a.Name == tag).SingleOrDefault();
                if(buf == null)
                {
                    buf = new Tags() { Name = tag };
                    db.Tags.Add(buf);
                }
                post.Tags.Add(buf);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var postEntity = db.Posts.Where(a => a.Id == id).SingleOrDefault();
            var post = Mapper.Map<Post, EditPostViewModel>(postEntity);
            return View(post);
        }
        [HttpPost]
        public ActionResult Edit(EditPostViewModel postView)
        {
            var post = Mapper.Map<EditPostViewModel, Post>(postView);
            db.Posts.Add(post);
            db.Entry(post).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var postEntity = db.Posts
                .Include("Author")
                .Include("Comments")
                .Include("Tags")
                .Where(a => a.Id == id)
                .SingleOrDefault();
            var post = Mapper.Map<Post, DetailsPostViewModel>(postEntity);
            return View(post);
        }
        public ActionResult Delete(int id)
        {
            var post = new Post { Id = id };
            db.Posts.Attach(post);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
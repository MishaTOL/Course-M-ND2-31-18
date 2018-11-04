using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2.Models;

namespace Lab2.Controllers
{
    public class PostsController : Controller
    {
        private NewsStudentDbContext db = new NewsStudentDbContext();
        public ActionResult Index()
        {
            IEnumerable<Post> posts = db.Posts.ToList();
            return View((User: (Student)Session["User"], Posts: posts));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Post post, string tags)
        {
            post.AuthorId = ((Student)Session["User"]).Id;
            foreach (var tag in tags.Split(' '))
            {
                var buf = db.Tags.Where(a => a.Name == tag).SingleOrDefault();
                db.TagsPosts.Add((buf == null)
                    ? new TagsPosts() {
                        Tags = new Tags() { Name = tag },
                        Post = post
                    }
                    : new TagsPosts() {
                        IdTag = buf.Id,
                        Tags = buf,
                        Post = post
                    });
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.Posts.Where(a => a.Id == id).SingleOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(Post post)
        {
            db.Posts.Add(post);
            db.Entry(post).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            return View(db.Posts.Include("Author").Include("Comments").Where(a => a.Id == id).SingleOrDefault());
        }
        public ActionResult Delete(int id)
        {
            var post = new Post { Id = id };
            db.Posts.Attach(post);
            db.Posts.Remove(post);
            db.TagsPosts.RemoveRange(db.TagsPosts.Where(a => a.Post.Id == post.Id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
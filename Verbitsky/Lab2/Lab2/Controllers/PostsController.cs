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
        private NewsStudentDbContext db = new NewsStudentDbContext();
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
        public ActionResult Create(CreatePostViewModel _post)
        {
            string tags = _post.Tags;
            _post.Tags = null;

            var post = Mapper.Map<CreatePostViewModel, Post>(_post);
            post.AuthorId = ((Student)Session["User"]).Id;
            db.Posts.Add(post);
            db.SaveChanges();
            post = db.Entry(post).Entity;

            foreach (var tag in tags.Split(' ').Distinct())
            {
                var buf = db.Tags.Where(a => a.Name == tag).SingleOrDefault();
                if(buf == null)
                {
                    db.Tags.Add(new Tags() { Name = tag });
                    db.SaveChanges();
                    buf = db.Tags.Where(a => a.Name == tag).SingleOrDefault();
                }
                post.Tags.Add(buf);
            }
            db.SaveChanges();

            //foreach (var tag in tags.Split(' ').Distinct())
            //{
            //    var buf = db.Tags.Where(a => a.Name == tag).SingleOrDefault();
            //    db.TagsPosts.Add((buf == null)
            //        ? new TagsPosts() {
            //            Tags = new Tags() { Name = tag },
            //            IdPost = post.Id,
            //            Post = post
            //        }
            //        : new TagsPosts() {
            //            IdTag = buf.Id,
            //            Tags = buf,
            //            IdPost = post.Id,
            //            Post = post
            //        });
            //    db.SaveChanges();
            //}
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var post = Mapper.Map<Post, EditPostViewModel>(db.Posts.Where(a => a.Id == id).SingleOrDefault());
            return View(post);
        }
        [HttpPost]
        public ActionResult Edit(EditPostViewModel _post)
        {
            var post = Mapper.Map<EditPostViewModel, Post>(_post);
            db.Posts.Add(post);
            db.Entry(post).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var post = Mapper.Map<Post, DetailsPostViewModel>(db.Posts
                .Include("Author")
                .Include("Comments")
                .Include("Tags")
                .Where(a => a.Id == id)
                .SingleOrDefault());
            return View(post);
        }
        public ActionResult Delete(int id)
        {
            var post = new Post { Id = id };
            db.Posts.Attach(post);
            db.Posts.Remove(post);
            //db.TagsPosts.RemoveRange(db.TagsPosts.Where(a => a.Post.Id == post.Id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
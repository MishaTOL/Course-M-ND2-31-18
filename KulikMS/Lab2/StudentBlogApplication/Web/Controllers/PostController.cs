using Domain.Contracts.Models;
using Domain.Contracts.Services;
using System.Linq;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IService<PostView> postService;
        public PostController(IService<PostView> postService)
        {
            this.postService = postService;
        }

        public ActionResult Index(int? authorId)
        {
            var studentPosts = authorId.HasValue
                ? postService.GetAll()
                    .Where(p => p.AuthorId == authorId)
                : postService.GetAll();

            ViewBag.UserId = Session["userId"];
            return View(studentPosts.OrderBy(p => p.Created));
        }

        public ActionResult Details(int id)
        {
            var post = postService.GetById(id);
            return post != null ? View(post) : View("Error");
        }

        public ActionResult Create()
        {
            return View(new PostView { AuthorId = (int)Session["userId"] });
        }

        [HttpPost]
        public ActionResult Create(PostView post)
        {
            try
            {
                postService.Add(post);
                return RedirectToAction("Index", new { authorId = post.AuthorId });
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Edit(int id)
        {
            var post = postService.GetById(id);
            return post != null ? View(post) : View("Error");
        }

        [HttpPost]
        public ActionResult Edit(PostView post)
        {
            try
            {
                postService.Update(post);
                return RedirectToAction("Index", new { authorId = post.AuthorId });
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Delete(int id)
        {
            var post = postService.GetById(id);
            return post != null ? View(post) : View("Error");
        }

        [HttpPost]
        public ActionResult Delete(PostView post)
        {
            try
            {
                postService.Delete(post.Id);
                return RedirectToAction("Index", new { authorId = post.AuthorId });
            }
            catch
            {
                return View("Error");
            }
        }
    }
}

using Domain.Contracts.Models;
using Domain.Contracts.Services;
using System.Linq;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly IService<CommentView> commentService;
        public CommentController(IService<CommentView> commentService)
        {
            this.commentService = commentService;
        }

        public ActionResult Create(int postId)
        {
            return View(new CommentView { PostId = postId, AuthorId = (int)Session["userId"] });
        }

        [HttpPost]
        public ActionResult Create(CommentView comment)
        {
            try
            {
                commentService.Add(comment);
                return RedirectToAction("Details", "Post", new { id = comment.PostId });
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Edit(int id)
        {
            var comment = commentService.GetById(id);
            return comment != null ? View(comment) : View("Error");
        }

        [HttpPost]
        public ActionResult Edit(CommentView comment)
        {
            try
            {
                commentService.Update(comment);
                return RedirectToAction("Details", "Post", new { id = comment.PostId });
            }
            catch
            {
                return View("Error");
            }
        }
    }
}

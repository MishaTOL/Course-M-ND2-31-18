using Lab2.Domain.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class TagController : Controller
    {
        private TagService service;

        public TagController()
        {
            service = new TagService();
        }
        
        [HttpGet]
        public ActionResult Index(int postId)
        {
            var tags = service.GetPostTags(postId);
            return View(tags);
        }
    }
}
using Lab3.Models;
using System.Web.Mvc;
using Ninject;
using Lab3.Util;
using System.ComponentModel;

namespace Lab3.Controllers
{
    public class HomeController : Controller
    {
        
        public object repository = (IRepository)System.Web.HttpContext.Current.Application["repository"];

        public HomeController() { }

        public HomeController(IRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index()
        {
            return View(((IRepository)repository).List());
        }
    }
}
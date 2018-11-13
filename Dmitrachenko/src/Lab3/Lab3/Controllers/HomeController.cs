using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace Lab3.Controllers
{
    public class HomeController : Controller
    {
        IRepository repository;

        public HomeController(IRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index()
        {
            return View(repository.List());
        }
    }
}
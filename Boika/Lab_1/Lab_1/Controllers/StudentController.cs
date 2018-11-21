using Lab_1.Models;
using System.Web.Mvc;

namespace Lab_1.Controllers
{
    public class StudentController : Controller
    {
        private DbContext dbContext;

        public StudentController()
        {
            dbContext = new DbContext();
        }

        public ActionResult Index()
        {
            return View(dbContext.Read());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            dbContext.Create(student);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View(dbContext.Read());
        }

        [ HttpPost]
        public ActionResult Delete(int id)
        {
            dbContext.Delete(id);
            return RedirectToAction("Delete");
        }

        [HttpGet]
        public ActionResult Update()
        {
            return View(dbContext.Read());
        }

        [HttpPost]
        public ActionResult Update(Student student)
        {
            dbContext.Update(student);
            return RedirectToAction("Update");
        }
    }
}
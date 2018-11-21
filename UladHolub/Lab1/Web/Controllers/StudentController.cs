using Domain.Contracts.Entity;
using Domain.Contracts.Interfaces;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class StudentController : Controller
    {
        private IService studentService;

        public StudentController(IService service)
        {
            studentService = service;
        }

        [HttpGet]
        public ActionResult Show()
        {
            var students = studentService.GetAll();
            return View(students);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel student)
        {
            if(student == null) { return RedirectToAction("Show"); }
            studentService.Create(student);
            return RedirectToAction("Show");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int studentId)
        {
            return RedirectToAction("Modify" , new { studentId = studentId });
        }

        [HttpGet]
        public ActionResult Modify(int studentId)
        {
            var student = studentService.Get(studentId);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(StudentViewModel student)
        {
            studentService.Update(student);
            return RedirectToAction("Show");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int studentId)
        {
            studentService.Delete(studentId);
            return RedirectToAction("Show");
        }
    }
}
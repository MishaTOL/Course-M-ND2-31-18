using Domain.Contracts.Repositories;
using Domain.Contracts.ViewModel;
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
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(StudentViewModel student)
        {
            var id = studentService.GetOrCreateStudent(student).Id;
            return RedirectToAction("ShowList", "Post", new { id = id });
        }
    }
}
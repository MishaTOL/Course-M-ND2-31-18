using Domain.Contracts.Models;
using Domain.Contracts.Services;
using System.Linq;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IService<StudentView> studentService;
        public StudentController(IService<StudentView> studentService)
        {
            this.studentService = studentService;
        }

        public ActionResult Login()
        {
            return View(new StudentView());
        }

        [HttpPost]
        public ActionResult Login(StudentView student)
        {
            var existingStudent = studentService.GetAll()
                .FirstOrDefault(s => s.LastName == student.LastName 
                                     && s.FirstName == student.FirstName);
            if (existingStudent == null)
            {
                existingStudent = studentService.Add(student);
            }
            Session["userId"] = existingStudent.Id;
            
            return RedirectToAction("Index", "Post");
        }
    }
}
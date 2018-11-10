using PresentationModel;
using Students.ServicesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsAutomationProject.Controllers
{
    public class AuthorizationController : Controller
    {
        IInfoModelService<StudentInfo> studentsService = new Students.Services.Services.StudentsService();
        // GET: Authorization
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(StudentViewModel student)
        {
            var existStudent = studentsService.GetModelCollections().Where(x => x.FirstName == student.FirstName && x.LastName == student.LastName).FirstOrDefault();
            if (existStudent == null)
            {
                studentsService.Create(AutoMapper.Mapper.Map<StudentViewModel, StudentInfo>(student));
                existStudent = studentsService.GetModelCollections().Where(x => x.FirstName == student.FirstName && x.LastName == student.LastName).FirstOrDefault();
            }

            Session["studentLogin"] = AutoMapper.Mapper.Map<StudentInfo, StudentViewModel>(existStudent);
            return RedirectToAction("students", "students");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["studentLogin"] = null;
            return RedirectToAction("Login");
        }
    }
}
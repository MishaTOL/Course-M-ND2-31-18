using Students.Services.Services;
using StudentsAutomationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace StudentsAutomationProject.Controllers
{
    public class StudentsController : Controller
    {
        IStudentsService _studentsService;
        public StudentsController()
        {
            _studentsService = new StudentsService();
        }

        // GET: Stusents
        [HttpGet]
        public ActionResult Students()
        {
            var students = _studentsService.GetStudents();
            var studentsView = AutoMapper.Mapper.Map<IEnumerable<Students.ServicesModel.Student>, IEnumerable<StudentViewModel>>(students);
            return View(studentsView);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentViewModel student)
        {
            var studentServiceModel = AutoMapper.Mapper.Map<StudentViewModel, Students.ServicesModel.Student>(student);
            _studentsService.Create(studentServiceModel);
            return RedirectToAction("Students"); //new HttpStatusCodeResult(HttpStatusCode.Created);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var serviceModel = _studentsService.GetStudentById(id);
            return View(AutoMapper.Mapper.Map<Students.ServicesModel.Student, StudentViewModel>(serviceModel));
        }

        [HttpPost]
        public ActionResult Update(StudentViewModel student)
        {
            var serviceModel = AutoMapper.Mapper.Map<StudentViewModel, Students.ServicesModel.Student>(student);
            _studentsService.Update(serviceModel);
            return RedirectToAction("Students");
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            var student = _studentsService.GetStudentById(id);
            return View(AutoMapper.Mapper.Map<Students.ServicesModel.Student, StudentViewModel>(student));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _studentsService.Delete(id);
            return RedirectToAction("Students");
        }
    }
}
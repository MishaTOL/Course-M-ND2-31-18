using PresentationModel;
using Students.ServicesModel;
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
        IInfoModelService<StudentInfo> studentsService = new Students.Services.Services.StudentsService();
        public StudentsController()
        {

        }

        // GET: Stusents
        [HttpGet]
        public ActionResult Students()
        {
            var students = studentsService.GetModelCollections();
            var studentsView = AutoMapper.Mapper.Map<IEnumerable<Students.ServicesModel.StudentInfo>
                , IEnumerable<StudentViewModel>>(students);
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
            var studentServiceModel = AutoMapper.Mapper.Map<StudentViewModel, Students.ServicesModel.StudentInfo>(student);
            studentsService.Create(studentServiceModel);
            return RedirectToAction("Students"); //new HttpStatusCodeResult(HttpStatusCode.Created);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var serviceModel = studentsService.GetModelById(id);
            return View(AutoMapper.Mapper.Map<Students.ServicesModel.StudentInfo, StudentViewModel>(serviceModel));
        }

        [HttpPost]
        public ActionResult Update(StudentViewModel student)
        {
            var serviceModel = AutoMapper.Mapper.Map<StudentViewModel, Students.ServicesModel.StudentInfo>(student);
            studentsService.Update(serviceModel);
            return RedirectToAction("Students");
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            var student = studentsService.GetModelById(id);
            return View(AutoMapper.Mapper.Map<Students.ServicesModel.StudentInfo, StudentViewModel>(student));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            studentsService.Delete(id);
            return RedirectToAction("Students");
        }
    }
}
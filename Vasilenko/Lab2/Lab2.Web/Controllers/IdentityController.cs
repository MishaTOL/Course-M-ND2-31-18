using AutoMapper;
using Lab2.Business.Abstraction;
using Lab2.Business.Abstraction.Entity;
using Lab2.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Web.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IStudentService studentService;

        public IdentityController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        static IdentityController()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<StudentViewModel, Student>());
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(StudentViewModel model)          
        {     
            Student studentMap = Mapper.Map<StudentViewModel, Student>(model);
            var student = studentService.GetByCredits(model.FirstName, model.LastName);

            if ((model.FirstName != null)&&(model.LastName!=null))
            {
                if (student!=null)
                { 
                    return RedirectToAction("Posts", "Post", new { studentId = student.Id });
                }
                else
                {
                    var studentId = studentService.AddStudent(studentMap);

                    return RedirectToAction("Posts", "Post", new { studentId = studentId });
                }
            }
            else
            {
                return RedirectToAction("Index", "Identity");
            }  
        }
    }
}
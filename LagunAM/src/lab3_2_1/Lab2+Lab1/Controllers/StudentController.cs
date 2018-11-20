using AutoMapper;
using DBModels.Models;
using DBRepConUow.UnitOfWork;
using Lab2_Lab1.InfoModels;
using Lab2_Lab1.Services;
using Lab2_Lab1.ViewModels;
using Lab2_Lab1.ViewModels.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2_Lab1.Controllers
{
    public class StudentController : Controller
    {
        private IService<Student> studentService;
        public StudentController(IService<Student> studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public JsonResult CheckNickName(string NickName)
        {
            return Json(((StudentService)(studentService)).CheckNickName(NickName), 
                JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult CheckEmail(string Email)
        {
            return Json(((StudentService)(studentService)).CheckEmail(Email), 
                JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new AddView());
        }

        [HttpPost]
        public ActionResult Add(AddView addView)
        {
            if (ModelState.IsValid)
            {
                ((StudentService)(studentService)).Add(Mapper.Map<AddView, StudentInfo>(addView));
                return RedirectToAction("Login");
            }
            return View(addView);
        }

        [HttpGet]
        public ActionResult Edit(StudentInfo studentInfo)
        {
            return View(Mapper.Map<StudentInfo, EditView>(studentInfo));
        }

        [HttpPost]
        public ActionResult Edit(EditView editView)
        {
            if (ModelState.IsValid)
            {
                ((StudentService)(studentService)).Edit(Mapper.Map<EditView, StudentInfo>(editView));
                return RedirectToAction("login");
            }
            return View(editView);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginView());
        }

        [HttpPost]
        public ActionResult Login(LoginView loginView)
        {
            if (ModelState.IsValid)
            {
                StudentInfo studentInfo =
                    (((StudentService)(studentService)).Autentification(
                        Mapper.Map<LoginView, StudentInfo>(loginView)));
                if (studentInfo == null)
                {
                    return View(new LoginView { Error = true });
                }
                else
                {
                    return RedirectToAction("Index", "Post", 
                        Mapper.Map<StudentInfo, PostInfo>(studentInfo));
                }
            }
            return View(loginView);
        }
       
            
    }
}
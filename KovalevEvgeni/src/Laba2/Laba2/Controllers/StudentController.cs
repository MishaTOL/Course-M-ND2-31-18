using AutoMapper;
using Laba2.BusinessLogicLayer.DataTransferObject;
using Laba2.BusinessLogicLayer.Services;
using Laba2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laba2.Controllers
{
    public class StudentController : Controller
    {
        private OrderService orderService;

        public StudentController()
        {
            orderService = new OrderService();
        }

        // GET: Student
        public ActionResult Index()
        {
            return View(new StudentModel());
        }
        [HttpPost]
        public ActionResult Index(StudentModel student)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StudentDTO, StudentModel>()).CreateMapper();
            student = mapper.Map<StudentDTO, StudentModel>(orderService.ServiceStudent.GetStudent(student.FirstName, student.LastName));
            if (student != null)
            {
                Session["StudentId"] = student.StudentId.ToString();
                return RedirectToAction("Index","Post");
            }
            return View(new StudentModel());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab1.Models;
using System.Web.Mvc;

namespace Lab1.Controllers
{
    public class StudentController : Controller
    {
        private StudentSummariesService summariesService;
        private void InitializeSummariesService(HttpContextBase httpContext)
        {
            summariesService = new StudentSummariesService(
               HttpContext.Server.MapPath(StudentControllerConst.DefaultPath), StudentControllerConst.DefaultNameDB);
        }
        private void AddRedirect(HttpResponseBase response)
        {
            Response.AddHeader(StudentControllerConst.HeaderRefresh, string.Concat(StudentControllerConst.RedirectTime,
                string.Concat(";", StudentControllerConst.RedirectPage)));
        }
        public StudentController(StudentSummariesService summariesService)
        {
            this.summariesService = summariesService;
        }
        public StudentController()
        {
            
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewStudent()
        {
            return View();
        }

        [HttpPost]
        public ContentResult NewStudent(StudentSummary studentSummary)
        {
            if (summariesService == null)
            {
                InitializeSummariesService(HttpContext);
                AddRedirect(Response);
            }

            return Content(string.Concat(summariesService.NewStudent(studentSummary),
                string.Concat(Environment.NewLine, StudentControllerConst.RedirectMessage.Replace(
                    StudentControllerConst.ReplaceTime, StudentControllerConst.RedirectTime))));
        }

        [HttpGet]
        public ActionResult InfoStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InfoStudent(int ID)
        {
            if (summariesService == null)
                InitializeSummariesService(HttpContext);
            return View(summariesService.StudentInfo(ID));
        }

        [HttpGet]
        public ActionResult UpdateInfoStudent(int? ID)
        {
            if (ID != null)
            {
                if (summariesService == null)
                    InitializeSummariesService(HttpContext);
                StudentSummary studentSummary = summariesService.StudentInfo(ID.Value);
                return View(studentSummary);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult UpdateInfoStudent(StudentSummary studentSummary)
        {
            if (summariesService == null)
            {
                InitializeSummariesService(HttpContext);
                AddRedirect(Response);
            }

            return Content(string.Concat(summariesService.ChangeStudentInfo(studentSummary),
                string.Concat(Environment.NewLine, StudentControllerConst.RedirectMessage.Replace(
                    StudentControllerConst.ReplaceTime, StudentControllerConst.RedirectTime))));
        }

        [HttpGet]
        public ActionResult DeleteStudent(int? ID)
        {
            if (ID != null)
            {
                if (summariesService == null)
                    InitializeSummariesService(HttpContext);
                StudentSummary studentSummary = summariesService.StudentInfo(ID.Value);
                return View(studentSummary);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult DeleteStudent(StudentSummary studentSummary)
        {
            if (summariesService == null)
            {
                InitializeSummariesService(HttpContext);
                AddRedirect(Response);
            }
            return Content(string.Concat(summariesService.StudentOut(studentSummary),
               string.Concat(Environment.NewLine, StudentControllerConst.RedirectMessage.Replace(
                   StudentControllerConst.ReplaceTime, StudentControllerConst.RedirectTime))));
        }

        [HttpGet]
        public FileContentResult DownloadList()
        {
            if (summariesService == null)
                InitializeSummariesService(HttpContext);
            return File(new System.Text.UTF8Encoding().GetBytes(summariesService.SaveStudentSummariesInCSV()), "text/csv", "Report.csv");
        }



    }
}
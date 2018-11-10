using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Lab1.Models;
using Lab1.Controllers;
using System.Web.Mvc;

namespace Lab1.Tests.Controllers
{
    [TestClass]
    public class NewStudentTest
    {
        private Mock<StudentSummariesService> mockSummariesService;
        private StudentController studentController;
        private Mock<StudentSummary> mockStudentSummary;
       
        [TestInitialize]
        public void Initialize()
        {
           mockSummariesService = new Mock<StudentSummariesService>();
           mockStudentSummary = new Mock<StudentSummary>();
           studentController = new StudentController(mockSummariesService.Object);
        }

        [TestMethod]
        public void NewStudent()
        {
            int Expected = 0;
            ContentResult contentResult = studentController.NewStudent(mockStudentSummary.Object);
            Assert.AreEqual(Expected, contentResult.Content.ToString().IndexOf(NewStudentTestConst.ResultOk));
        }
        [TestMethod]
        public void NewStudentEmpty()
        {
            ViewResult viewResult = studentController.NewStudent() as ViewResult;
            Assert.IsNotNull(viewResult);
            Assert.IsNull(viewResult.Model);
        }
        [TestMethod]
        public void Index()
        {
            ViewResult result = studentController.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void InfoStudentEmpty()
        {
            ViewResult viewResult = studentController.InfoStudent() as ViewResult;
            Assert.IsNull(viewResult.Model);
            Assert.IsNotNull(viewResult);
        }
        [TestMethod]
        public void InfoStudentNegative()
        {
            int mockID = -1;
            ViewResult viewResult = studentController.InfoStudent(mockID) as ViewResult;
            Assert.IsNull(viewResult.Model);
            Assert.IsNotNull(viewResult);
        }
      
       
    }
}

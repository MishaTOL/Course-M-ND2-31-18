using AutoMapper;
using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class HomeController : Controller
    {
        StudentContext StudentNewsDb = new StudentContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChooseOrCreateStudent(string firstName, string lastName)
        {
            Student student = StudentNewsDb.Students.Where(s => (s.FirstName == firstName && s.LastName == lastName)).FirstOrDefault();
            if(student == null)
            {
                Student newStudent = new Student { FirstName = firstName, LastName = lastName };
                StudentNewsDb.Students.Add(newStudent);
                StudentNewsDb.SaveChanges();
                return RedirectToAction("NewsListForm", newStudent);
            }
            return RedirectToAction("NewsListForm", student);
        }

        public ActionResult NewsListForm(Student student)
        {
            StudentNewsDb.CurrentStudent.RemoveRange(StudentNewsDb.CurrentStudent);
            var currentStudent = Mapper.Map<Student, CurrentStudent>(student);
            StudentNewsDb.CurrentStudent.Add(currentStudent);
            StudentNewsDb.SaveChanges();
            var posts = StudentNewsDb.Posts.OrderByDescending(p => p.DateOfCreation).ToList();
            return View(Tuple.Create(currentStudent, posts));
        }

        public ActionResult CreateNewPostForm(CurrentStudent currentStudent)
        {
            return View(currentStudent);
        }

        public ActionResult CreateNewPost(string Description, string Content, string TagsStr, CurrentStudent currentStudent)
        {
            Post newPost = new Post();
            Student student = StudentNewsDb.Students.Where(s => (s.FirstName == currentStudent.FirstName && s.LastName == currentStudent.LastName)).FirstOrDefault();
            newPost.Student = student;
            newPost.StudentId = student.Id;
            newPost.Description = Description;
            newPost.Content = Content;
            newPost.DateOfCreation = DateTime.Now;

            String[] TagsStringArray = TagsStr.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(var tagName in TagsStringArray)
            {
                newPost.Tags.Add(new Tag { Name = tagName });
            }
            StudentNewsDb.Posts.Add(newPost);
            StudentNewsDb.SaveChanges();
            return RedirectToAction("NewsListForm", student);
        }

        public ActionResult ReadPost(int Id)
        {
            Post post = StudentNewsDb.Posts.Find(Id);
            CurrentStudent currentStudent = StudentNewsDb.CurrentStudent.First();
            Student student = StudentNewsDb.Students.Where(s => (s.FirstName == currentStudent.FirstName && s.LastName == currentStudent.LastName)).FirstOrDefault();
            return View(Tuple.Create(student, post));
            
        }
        public ActionResult AddComment(string CommentText , int Id)
        {
            CurrentStudent currentStudent = StudentNewsDb.CurrentStudent.First();
            Student student = StudentNewsDb.Students.Where(s => (s.FirstName == currentStudent.FirstName && s.LastName == currentStudent.LastName)).FirstOrDefault();
            Comment newComment = new Comment();
            newComment.Content = CommentText;
            newComment.PostId = Id;
            newComment.Post = StudentNewsDb.Posts.Find(Id);
            newComment.AuthorId = student.Id;
            newComment.DateOfCreation = DateTime.Now;
            StudentNewsDb.Comments.Add(newComment);
            StudentNewsDb.SaveChanges();
            return View();
        }

        public ActionResult Edit(int Id)
        {
            Post post = StudentNewsDb.Posts.Find(Id);
            CurrentStudent currentStudent = StudentNewsDb.CurrentStudent.First();
            Student student = StudentNewsDb.Students.Where(s => (s.FirstName == currentStudent.FirstName && s.LastName == currentStudent.LastName)).FirstOrDefault();
            if (post.StudentId != student.Id)
                return View("EditDeleteErrorView");
            StringBuilder tagStr = new StringBuilder();
            foreach (var tag in post.Tags)
                tagStr.AppendFormat("#" + tag.Name);
            TempData["TagStr"] = tagStr;
            return View(Tuple.Create(student, post));
        }

        public ActionResult EditPost(int Id, string Description, string Content, string TagsStr)
        {
            Post post = StudentNewsDb.Posts.Find(Id);
            post.Description = Description;
            post.Content = Content;
            String[] TagsStringArray = TagsStr.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
            post.Tags.Clear();
            foreach (var tagName in TagsStringArray)
            {
                post.Tags.Add(new Tag { Name = tagName });
            }
            StudentNewsDb.SaveChanges();
            CurrentStudent currentStudent = StudentNewsDb.CurrentStudent.First();
            Student student = StudentNewsDb.Students.Where(s => (s.FirstName == currentStudent.FirstName && s.LastName == currentStudent.LastName)).FirstOrDefault();
            return RedirectToAction("NewsListForm", student);
        }
        public ActionResult DeletePost(int Id)
        {
            Post post = StudentNewsDb.Posts.Find(Id);
            CurrentStudent currentStudent = StudentNewsDb.CurrentStudent.First();
            Student student = StudentNewsDb.Students.Where(s => (s.FirstName == currentStudent.FirstName && s.LastName == currentStudent.LastName)).FirstOrDefault();
            if (post.StudentId != student.Id)
                return View("EditDeleteErrorView");
            StudentNewsDb.Posts.Remove(post);
            StudentNewsDb.SaveChanges();
            return RedirectToAction("NewsListForm", student);
        }
    }
}
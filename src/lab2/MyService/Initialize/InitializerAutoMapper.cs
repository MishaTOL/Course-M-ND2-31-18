using AutoMapper;
using Lab2.Models;
using Lab2.Models.db;
using Lab2.MyService.Domain.Interface;
using Lab2.MyService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.MyService.Initialize
{
    public static class InitializerAutoMapper
    {
        public static void Initialize()
        {
            InitializeAutoMapper();
        }
        private static void InitializeAutoMapper()
        {
            Mapper.Initialize(
                cfg => cfg.CreateMap<Postdb, Post>()
                .AfterMap((s, d) =>
                {
                    //Author
                    IStudentDbRepository<Studentdb> rStudents = new StudentDbRepository();
                    Studentdb studentdb = rStudents.Get(s.StudentId);
                    d.Author = $"{studentdb.FirstName} {studentdb.LastName}";
                    //Commentsdb
                    ICommentDbRepository<Commentdb> rCommentsdb = new CommentDbRepository();
                    IEnumerable<Commentdb> commentsdb = rCommentsdb.GetAll(s.Id);
                    //
                    List<Comment> comments = new List<Comment>();
                    //Commentdb+Author
                    foreach (var commentdb in commentsdb)
                    {
                        Comment comment = new Comment() { Id = commentdb.Id, Content = commentdb.Content, Created = commentdb.Created };
                        Studentdb student = rStudents.Get(commentdb.StudentId);
                        comment.Author = $"{student.FirstName} {student.LastName}";
                        comments.Add(comment);
                    }
                    //
                    d.Comments = comments;
                    //Tags
                    ITagDbRepository<Tagdb> rTags = new TagDbRepository();
                    d.Tags = rTags.GetAll(s.Id);
                }));
        }
    }
}
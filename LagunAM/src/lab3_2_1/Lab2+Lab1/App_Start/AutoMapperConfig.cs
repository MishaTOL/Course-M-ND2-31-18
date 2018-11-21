using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DBModels.Models;
using Lab2_Lab1.InfoModels;
using Lab2_Lab1.ViewModels.Student;
using Lab2_Lab1.ViewModels.Post;
using Lab2_Lab1.ViewModels.Comment;

namespace Lab2_Lab1.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<StudentInfo, Student>();
                cfg.CreateMap<Student, StudentInfo>();
                cfg.CreateMap<ViewModels.Student.AddView, StudentInfo>();
                cfg.CreateMap<StudentInfo, ViewModels.Student.AddView>();
                cfg.CreateMap<ViewModels.Student.EditView, StudentInfo>();
                cfg.CreateMap<StudentInfo, ViewModels.Student.EditView>();
                cfg.CreateMap<LoginView, StudentInfo>();
                cfg.CreateMap<StudentInfo, LoginView>();

                cfg.CreateMap<PostInfo, Post>();
                cfg.CreateMap<Post, PostInfo>();
                cfg.CreateMap<StudentInfo, PostInfo>();
                cfg.CreateMap<PostInfo, ViewModels.Post.AddView>();
                cfg.CreateMap<ViewModels.Post.AddView, PostInfo>();
                cfg.CreateMap<ViewModels.Post.EditView, PostInfo>();
                cfg.CreateMap<PostInfo, ViewModels.Post.EditView>();
                cfg.CreateMap<Post, CommentInfo>();
                cfg.CreateMap<PostInfo, ViewModels.Post.IndexView>();

                cfg.CreateMap<CommentInfo, Comment>();
                cfg.CreateMap<Comment, CommentInfo>();
                cfg.CreateMap<CommentInfo, ViewModels.Comment.IndexView>();
                cfg.CreateMap<CommentInfo, AddEditView>();
                cfg.CreateMap<AddEditView, CommentInfo>();
            }
            );

        }
    }
}
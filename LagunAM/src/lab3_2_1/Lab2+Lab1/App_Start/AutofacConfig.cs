using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Autofac;
using Autofac.Builder;
using Autofac.Integration.Mvc;
using DBModels.Models;
using DBRepConUow.Context;
using DBRepConUow.Repositarys;
using DBRepConUow.UnitOfWork;
using Lab2_Lab1.Services;

namespace Lab2_Lab1.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<StudentRepositary>().As<IRepositary<int, Student>>();
            builder.RegisterType<CommentRepositary>().As<IRepositary<int, Comment>>();
            builder.RegisterType<PostRepositary>().As<IRepositary<int, Post>>();
            builder.RegisterType<TagRepositary>().As<IRepositary<int, Tag>>();
            builder.RegisterType<ForumUOW>().As<IForumUOW>()
                .WithParameter("forumContext", new ForumContext());
            builder.RegisterType<StudentService>().As<IService<Student>>();
            builder.RegisterType<PostService>().As<IService<Post>>();
            builder.RegisterType<CommentService>().As<IService<Comment>>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
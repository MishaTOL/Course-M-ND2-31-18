using Lab2.Business.Abstraction;
using Lab2.Business.Service;
using Lab2.DataAccess.Abstraction;
using Lab2.DataAccess.Context;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace Lab2.DependencyInjection
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IContextFactory>().To<ContextFactory>();
            Bind<IStudentService>().To<StudentService>();
            Bind<IPostService>().To<PostService>();
            Bind<ICommentService>().To<CommentService>();
            Bind<ITagService>().To<TagService>();
        }
    }
}

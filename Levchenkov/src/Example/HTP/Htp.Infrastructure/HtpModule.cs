using Autofac;
using Autofac.Core;
using Htp.Data.Contracts.Repositories;
using Htp.Domain.Contracts.Services;
using Htp.Domain.Services;
using Htp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Htp.Infrastructure
{
    public class HtpModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            //continer.Register<interface, class>();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>().AsSelf();
            builder.RegisterType<StudentRepository2>().As<IStudentRepository>().AsSelf();

            builder.RegisterType<StudentService>().As<IStudentService>().WithParameter(
                new ResolvedParameter(
                    (pi, ctx) => pi.ParameterType == typeof(IStudentRepository),
                    (pi, ctx) => ctx.Resolve<StudentRepository2>()));
        }
    }
}

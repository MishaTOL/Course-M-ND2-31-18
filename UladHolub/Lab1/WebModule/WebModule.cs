using Autofac;
using Autofac.Core;
using Contracts.Interfaces;
using Data.Services.Services;
using Domain.Contracts.Interfaces;
using Repositories.Repository;

namespace WebModule
{
    public class WebModule : Module
    {
        public string ConnectionString{ get; set; }
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork> ().AsSelf();
            builder.RegisterType<StudentService>().As<IService>().AsSelf();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
                .WithParameter(new TypedParameter(typeof(string), ConnectionString));
            builder.RegisterType<StudentService>().As<IService>().WithParameter(
                new ResolvedParameter(
                    (pi, ctx) => pi.ParameterType == typeof(IUnitOfWork),
                    (pi, ctx) => ctx.Resolve<UnitOfWork>(new TypedParameter(typeof(string), ConnectionString))));
        }
    }
}

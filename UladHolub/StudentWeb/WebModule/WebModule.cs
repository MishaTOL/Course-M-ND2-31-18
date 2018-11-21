using Autofac;
using Autofac.Core;
using Data.Contracts.Repositories;
using Data.Repositories.Repositories;
using Domain.Contracts.Repositories;

namespace WebModule
{
    public class WebModule : Module
    {
        public string ConnectionString { get; set; }
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<EntityFrameworkUnitOfWork>().As<IUnitOfWork>().AsSelf();
            builder.RegisterType<Domain.Services.Services.Service>().As<IService>().AsSelf();

            builder.RegisterType<EntityFrameworkUnitOfWork>().As<IUnitOfWork>()
                .WithParameter(new TypedParameter(typeof(string), ConnectionString));
            builder.RegisterType<Domain.Services.Services.Service>().As<IService>().WithParameter(
                new ResolvedParameter(
                    (pi, ctx) => pi.ParameterType == typeof(IUnitOfWork),
                    (pi, ctx) => ctx.Resolve<EntityFrameworkUnitOfWork>(new TypedParameter(typeof(string), ConnectionString))));
        }
    }
}

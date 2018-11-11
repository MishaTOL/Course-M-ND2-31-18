using Data.Repositories;
using MyDependencyInjectionContainer.Abstract;
using Web.Controllers;
using Data.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Services;

namespace Web.Infrastructure
{
    public static class Configuration
    {
        public static void Configure(IContainer container)
        {
            container.Bind<StudentController>().With<StudentController>();
            container.Bind<IStudentService>().With<StudentService>();
            container.Bind<IStudentRepository>().With<StudentRepository>();
        }
    }
}
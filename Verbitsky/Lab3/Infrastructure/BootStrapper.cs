using Data.Repositories;
using MyDependencyInjectionContainer;
using Web.Controllers;
using Data.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Services;

namespace Infrastructure
{
    public static class BootStrapper
    {
        public static void Configure(IContainer container)
        {
            container.Register<StudentController, StudentController>();
            container.Register<IStudentService, StudentService>();
            container.Register<IStudentRepository, StudentRepository>();
        }
    }
}
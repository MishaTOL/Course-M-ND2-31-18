using Demo.Contexts;
using Demo.Contracts;
using Container;
using Demo.Repositories;
using Demo.Services;
using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IContainer container = new MyContainer();
            container.RegisterType<IContext, DbContext>();
            container.RegisterType<IStudentRepository, StudentRepository>();
            container.RegisterType<IStudentService, StudentService>();

            IResolver resolver = new MyResolver(container);
            var studentService = resolver.GetInstance(typeof(IStudentService));

            Console.Read();
        }
    }
}

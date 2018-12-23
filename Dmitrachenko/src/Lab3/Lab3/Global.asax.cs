using Lab3.Models;
using Lab3.Util;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Lab3
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            DiContainer container = new DiContainer();
            //Регистрация для работы с MS SQL Server
            container.Register<IRepository, StudentRepository>();

            //Регистрация для работы с JSON File
            //container.Register<IRepository, StudentFileRepository>();

            IRepository repository = container.Resolve<IRepository>();
            Application.Add("repository", repository);


            // Внедрение зависимостей для Ninject
            //NinjectModule registrations = new NinjectRegistrations();
            //var kernel = new StandardKernel(registrations);
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}

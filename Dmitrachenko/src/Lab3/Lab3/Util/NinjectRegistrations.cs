using Ninject.Modules;
using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            //MS SQL Server
            Bind<IRepository>().To<StudentRepository>();

            //JSON File
            //Bind<IRepository>().To<StudentFileRepository>();
        }
    }
}
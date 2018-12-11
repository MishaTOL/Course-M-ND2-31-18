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
            //Подключение для работы с MS SQL Server
            //Bind<IRepository>().To<StudentRepository>();

            //Подключение для работы с JSON File
            //Bind<IRepository>().To<StudentFileRepository>();
        }
    }
}
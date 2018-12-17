using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsAutomationProject.App_Start
{
    public static class Initializer
    {
        public static void Initialize()
        {
            InitializeAutomapper();
        }

        private static void InitializeAutomapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Models.StudentViewModel, Students.ServicesModel.Student>();
                cfg.CreateMap<Students.ServicesModel.Student, Models.StudentViewModel>();
            });
        }
    }
}
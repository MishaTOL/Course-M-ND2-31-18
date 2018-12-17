using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

[assembly:  WebActivatorEx.PostApplicationStartMethod(typeof(Students.Services.Initializer), "Initialize")]

namespace Students.Services
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
                cfg.CreateMap<RepositoryModel.Student, ServicesModel.Student>();
                cfg.CreateMap<ServicesModel.Student, RepositoryModel.Student>();
            });
        }
    }
}

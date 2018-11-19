using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab2.Models;
using Lab2.Models.ViewModels.Posts;
using Lab2.Models.ViewModels.Comments;
using Lab2.Models.ViewModels.News;

namespace Lab2.Infrastructure
{
    public class AutomapperStudentProfile : AutoMapper.Profile
    {
        public AutomapperStudentProfile()
        {
            CreateMap<IndexStudentViewModel, Student>()
                .ForMember(a => a.FirstName, a => a.MapFrom(b => b.FirstName))
                .ForMember(a => a.LastName, a => a.MapFrom(b => b.LastName))
                .ForAllOtherMembers(a => a.Ignore());
        }
    }
}
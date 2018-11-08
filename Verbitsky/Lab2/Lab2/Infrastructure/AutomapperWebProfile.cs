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
    public class AutomapperWebProfile : AutoMapper.Profile
    {
        public AutomapperWebProfile()
        {
            CreateMap<Post, IndexPostViewModel>()
                .ForMember("Author", a => a.MapFrom(b => b.Author.FirstName));

            CreateMap<IndexStudentViewModel, Student>();

            CreateMap<CreatePostViewModel, Post>();
            
            CreateMap<Post, DetailsPostViewModel>()
                .ForMember("Author", a => a.MapFrom(b => b.Author.FirstName));

            CreateMap<CreateCommentViewModel, Comment>();

            CreateMap<Post, EditPostViewModel>();
            CreateMap<EditPostViewModel, Post>();

            CreateMap<Comment, EditCommentViewModel>();
            CreateMap<EditCommentViewModel, Comment>();

            CreateMap<Comment, PartialListCommentViewModel>()
                .ForMember("Author", a => a.MapFrom(b => b.Author.FirstName));
        }

        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a => a.AddProfile<AutomapperWebProfile>());
        }
    }
}
using AutoMapper;
using PresentationModel;
using Students.RepositoryModel;
using Students.ServicesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initializer
{
    public static class Initializer
    {
        public static void Initialize()
        {
            InitializeAutoMapper();
        }
        private static void InitializeAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                //viewModel => ServiceModel
                cfg.CreateMap<StudentViewModel, StudentInfo>();
                cfg.CreateMap<PostViewModel, PostInfo>()
                .ForMember(x => x.Author, q => q.Ignore())
                .ForMember(x => x.Comments, q => q.Ignore())
                .ForMember(x => x.Content, q => q.MapFrom(a => a.Content))
                .ForMember(x => x.CreatedDate, q => q.MapFrom(a => a.CreatedDate))
                .ForMember(x => x.Id, q => q.MapFrom(a => a.Id))
                .ForMember(x => x.StudentId, q => q.MapFrom(a => a.StudentId))
                .AfterMap((src, dest) => dest.Tags = src.TagsString.Split(' ').Select(d => new TagInfo() { Name = d }).ToList());
                //.ForMember(x => x.Tags, q => q.MapFrom(a => a.TagsString.Split(' ')))
                cfg.CreateMap<CommentViewModel, CommentInfo>();
                cfg.CreateMap<TagViewModel, TagInfo>();

                //Service => ViewModel
                cfg.CreateMap<StudentInfo, StudentViewModel>();
                cfg.CreateMap<PostInfo, PostViewModel>();
                cfg.CreateMap<CommentInfo, CommentViewModel>();
                cfg.CreateMap<TagInfo, TagViewModel>();

                //ServiceModel => DALModel
                cfg.CreateMap<StudentInfo, Student>();
                cfg.CreateMap<PostInfo, Post>();
                cfg.CreateMap<CommentInfo, Comment>();
                cfg.CreateMap<TagInfo, Tag>();

                //DALModel => ServiceModel
                cfg.CreateMap<Student, StudentInfo>();
                cfg.CreateMap<Post, PostInfo>();
                cfg.CreateMap<Comment, CommentInfo>();
                cfg.CreateMap<Tag, TagInfo>();


            });
        }
    }
}

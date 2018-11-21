using AutoMapper;
using Lab2.Data.Contracts;
using Lab2.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Infrastructure
{
    public class AutomapperWebProfile: Profile
    {
        public AutomapperWebProfile()
        {
            CreateMap<PostViewModel, PostEntity>();
            CreateMap<PostEntity, PostViewModel>();
            CreateMap<List<PostViewModel>, List<PostEntity>>();
            CreateMap<List<PostEntity>, List<PostViewModel>>();

            CreateMap<StudentViewModel, StudentEntity>();
            CreateMap<StudentEntity, StudentViewModel>();

            CreateMap<CommentViewModel, CommentEntity>();
            CreateMap<CommentEntity, CommentViewModel>();

            CreateMap<TagEntity, TagViewModel>();
            CreateMap<TagViewModel, TagEntity>();
        }

        public static void Run()
        {
            Mapper.Initialize(t =>
            {
                t.AddProfile<AutomapperWebProfile>();
            }
            );
        }
    }
}

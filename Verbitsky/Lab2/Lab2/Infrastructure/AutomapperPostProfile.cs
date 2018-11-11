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
    public class AutomapperPostProfile : AutoMapper.Profile
    {
        public AutomapperPostProfile()
        {
            CreateMap<Post, IndexPostViewModel>()
                .ForMember(a => a.Id, a => a.MapFrom(b => b.Id))
                .ForMember(a => a.AuthorId, a => a.MapFrom(b => b.AuthorId))
                .ForMember(a => a.Author, a => a.MapFrom(b => b.Author.FirstName))
                .ForMember(a => a.Header, a => a.MapFrom(b => b.Header))
                .ForMember(a => a.Content, a => a.MapFrom(b => b.Content))
                .ForMember(a => a.Created, a => a.MapFrom(b => b.Created))
                .ForAllOtherMembers(a => a.Ignore());

            CreateMap<CreatePostViewModel, Post>()
                .ForMember(a => a.Header, a => a.MapFrom(b => b.Header))
                .ForMember(a => a.Content, a => a.MapFrom(b => b.Content))
                .ForAllOtherMembers(a => a.Ignore());

            CreateMap<Post, DetailsPostViewModel>()
                .ForMember(a => a.Id, a => a.MapFrom(b => b.Id))
                .ForMember(a => a.AuthorId, a => a.MapFrom(b => b.AuthorId))
                .ForMember(a => a.Author, a => a.MapFrom(b => b.Author.FirstName))
                .ForMember(a => a.Header, a => a.MapFrom(b => b.Header))
                .ForMember(a => a.Content, a => a.MapFrom(b => b.Content))
                .ForMember(a => a.Created, a => a.MapFrom(b => b.Created))
                .ForMember(a => a.Comments, a => a.MapFrom(b => b.Comments))
                .ForMember(a => a.Tags, a => a.MapFrom(b => b.Tags))
                .ForAllOtherMembers(a => a.Ignore());

            CreateMap<Post, EditPostViewModel>()
                .ForMember(a => a.Id, a => a.MapFrom(b => b.Id))
                .ForMember(a => a.AuthorId, a => a.MapFrom(b => b.AuthorId))
                .ForMember(a => a.Header, a => a.MapFrom(b => b.Header))
                .ForMember(a => a.Content, a => a.MapFrom(b => b.Content))
                .ForAllOtherMembers(a => a.Ignore());
            CreateMap<EditPostViewModel, Post>();
        }
    }
}
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
    public class AutomapperCommentProfile : AutoMapper.Profile
    {
        public AutomapperCommentProfile()
        {
            CreateMap<CreateCommentViewModel, Comment>()
                .ForMember(a => a.PostId, a => a.MapFrom(b => b.PostId))
                .ForMember(a => a.Content, a => a.MapFrom(b => b.Content))
                .ForAllOtherMembers(a => a.Ignore());

            CreateMap<Comment, EditCommentViewModel>()
                .ForMember(a => a.Id, a => a.MapFrom(b => b.Id))
                .ForMember(a => a.PostId, a => a.MapFrom(b => b.PostId))
                .ForMember(a => a.AuthorId, a => a.MapFrom(b => b.AuthorId))
                .ForMember(a => a.Content, a => a.MapFrom(b => b.Content))
                .ForAllOtherMembers(a => a.Ignore());

            CreateMap<EditCommentViewModel, Comment>()
                .ForMember(a => a.Id, a => a.MapFrom(b => b.Id))
                .ForMember(a => a.PostId, a => a.MapFrom(b => b.PostId))
                .ForMember(a => a.AuthorId, a => a.MapFrom(b => b.AuthorId))
                .ForMember(a => a.Content, a => a.MapFrom(b => b.Content))
                .ForAllOtherMembers(a => a.Ignore());

            CreateMap<Comment, PartialListCommentViewModel>()
                .ForMember(a => a.Id, a => a.MapFrom(b => b.Id))
                .ForMember(a => a.PostId, a => a.MapFrom(b => b.PostId))
                .ForMember(a => a.AuthorId, a => a.MapFrom(b => b.AuthorId))
                .ForMember(a => a.Author, a => a.MapFrom(b => b.Author))
                .ForMember(a => a.Content, a => a.MapFrom(b => b.Content))
                .ForMember(a => a.Created, a => a.MapFrom(b => b.Created))
                .ForMember(a => a.Author, a => a.MapFrom(b => b.Author.FirstName));
        }
    }
}
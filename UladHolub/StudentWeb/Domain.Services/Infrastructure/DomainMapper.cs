using AutoMapper;
using Data.Contracts.Entities;
using Domain.Contracts.ViewModel;

namespace Domain.Services.Infrastructure
{
    public static class DomainMapper
    {
        private static IMapper mapper;
        public static IMapper Mapper { get { return mapper; } }

        static DomainMapper()
        {
            mapper = new MapperConfiguration(
               cfg =>
               {
                   cfg.CreateMap<StudentViewModel, Student>()
                       .ForMember(d => d.StudentId, opt => opt.MapFrom(src => src.Id))
                       .ForMember(d => d.Comments, opt => opt.MapFrom(src => src.Comments))
                       .ForMember(d => d.FirstName, opt => opt.MapFrom(src => src.FirstName))
                       .ForMember(d => d.LastName, opt => opt.MapFrom(src => src.LastName))
                       .ForMember(d => d.Posts, opt => opt.MapFrom(src => src.Posts))
                       .ReverseMap()
                       .ForMember(d => d.Id, opt => opt.MapFrom(src => src.StudentId))
                       .ForMember(d => d.Comments, opt => opt.MapFrom(src => src.Comments))
                       .ForMember(d => d.FirstName, opt => opt.MapFrom(src => src.FirstName))
                       .ForMember(d => d.LastName, opt => opt.MapFrom(src => src.LastName))
                       .ForMember(d => d.Posts, opt => opt.MapFrom(src => src.Posts));
                   cfg.CreateMap<PostViewModel, Post>()
                       .ForMember(d => d.PostId, opt => opt.MapFrom(src => src.Id))
                       .ForMember(d => d.Author, opt => opt.MapFrom(src => src.Author))
                       .ForMember(d => d.AuthorId, opt => opt.MapFrom(src => src.AuthorId))
                       .ForMember(d => d.Comments, opt => opt.MapFrom(src => src.Comments))
                       .ForMember(d => d.Content, opt => opt.MapFrom(src => src.Content))
                       .ForMember(d => d.Created, opt => opt.MapFrom(src => src.Created))
                       .ForMember(d => d.Tags, opt => opt.MapFrom(src => src.Tags))
                       .ForMember(d => d.Title, opt => opt.MapFrom(src => src.Title))
                       .ReverseMap()
                       .ForMember(d => d.Id, opt => opt.MapFrom(src => src.PostId))
                       .ForMember(d => d.Author, opt => opt.MapFrom(src => src.Author))
                       .ForMember(d => d.AuthorId, opt => opt.MapFrom(src => src.AuthorId))
                       .ForMember(d => d.Comments, opt => opt.MapFrom(src => src.Comments))
                       .ForMember(d => d.Content, opt => opt.MapFrom(src => src.Content))
                       .ForMember(d => d.Created, opt => opt.MapFrom(src => src.Created))
                       .ForMember(d => d.Tags, opt => opt.MapFrom(src => src.Tags))
                       .ForMember(d => d.Title, opt => opt.MapFrom(src => src.Title));
                   cfg.CreateMap<TagViewModel, Tag>()
                       .ForMember(d => d.TagId, opt => opt.MapFrom(src => src.Id))
                       .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                       .ForMember(d => d.Posts, opt => opt.MapFrom(src => src.Posts))
                       .ReverseMap()
                       .ForMember(d => d.Id, opt => opt.MapFrom(src => src.TagId))
                       .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                       .ForMember(d => d.Posts, opt => opt.MapFrom(src => src.Posts));
                   cfg.CreateMap<CommentViewModel, Comment>()
                       .ForMember(d => d.CommentId, opt => opt.MapFrom(src => src.Id))
                       .ForMember(d => d.Author, opt => opt.MapFrom(src => src.Author))
                       .ForMember(d => d.AuthorId, opt => opt.MapFrom(src => src.AuthorId))
                       .ForMember(d => d.Content, opt => opt.MapFrom(src => src.Content))
                       .ForMember(d => d.Created, opt => opt.MapFrom(src => src.Created))
                       .ForMember(d => d.Post, opt => opt.MapFrom(src => src.Post))
                       .ForMember(d => d.PostId, opt => opt.MapFrom(src => src.PostId))
                       .ReverseMap()
                       .ForMember(d => d.Id, opt => opt.MapFrom(src => src.CommentId))
                       .ForMember(d => d.Author, opt => opt.MapFrom(src => src.Author))
                       .ForMember(d => d.AuthorId, opt => opt.MapFrom(src => src.AuthorId))
                       .ForMember(d => d.Content, opt => opt.MapFrom(src => src.Content))
                       .ForMember(d => d.Created, opt => opt.MapFrom(src => src.Created))
                       .ForMember(d => d.Post, opt => opt.MapFrom(src => src.Post))
                       .ForMember(d => d.PostId, opt => opt.MapFrom(src => src.PostId));
               }).CreateMapper();
        }
    }
}

using AutoMapper;
using Data.Contracts.Models;
using Domain.Contracts.Models;

namespace Infrastructure
{
    public class AutoMapperConfiguration
    {
        public IMapper ConfigureMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student, StudentView>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                    .ForMember(dest => dest.Posts, opt => opt.MapFrom(src => src.Posts))
                    .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
                    .ReverseMap();

                cfg.CreateMap<Post, PostView>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                    .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId))
                    .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
                    .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                    .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                    .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                    .ReverseMap();

                cfg.CreateMap<Comment, CommentView>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                    .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId))
                    .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                    .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                    .ForMember(dest => dest.Post, opt => opt.MapFrom(src => src.Post))
                    .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId))
                    .ReverseMap();

                cfg.CreateMap<Tag, TagView>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Posts, opt => opt.MapFrom(src => src.Posts))
                    .ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}

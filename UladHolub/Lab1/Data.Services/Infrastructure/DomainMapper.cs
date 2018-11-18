using AutoMapper;
using Contracts.Entity;
using Domain.Contracts.Entity;

namespace Data.Services.Infrastructure
{
    internal static class DomainMapper
    {
        private static IMapper mapper;
        public static IMapper Mapper { get { return mapper; } }

        static DomainMapper()
        {
            mapper = new MapperConfiguration(
               cfg =>
               {
                   cfg.CreateMap<StudentViewModel, Student>()
                   .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(d => d.FirstName, opt => opt.MapFrom(src => src.FirstName))
                   .ForMember(d => d.LastName, opt => opt.MapFrom(src => src.LastName))
                   .ReverseMap()
                   .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(d => d.FirstName, opt => opt.MapFrom(src => src.FirstName))
                   .ForMember(d => d.LastName, opt => opt.MapFrom(src => src.LastName));
               }).CreateMapper();
        }
    }
}

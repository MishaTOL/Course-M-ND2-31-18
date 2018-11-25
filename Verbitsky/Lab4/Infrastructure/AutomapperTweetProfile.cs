using AutoMapper;
using Data.Contracts.Models;
using DomainContracts.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Infrastructure
{
    public class AutomapperTweetProfile : AutoMapper.Profile
    {
        public AutomapperTweetProfile()
        {
            CreateMap<TweetViewModel, TweetEntity>()
                .ForPath(a => a.Author.FirstName, a => a.MapFrom(b => b.Author));
            //.ForMember(a => a.Head, a => a.MapFrom(b => b.Head))
            //.ForMember(a => a.Content, a => a.MapFrom(b => b.Content))
            //.ForAllOtherMembers(a => a.Ignore());

            CreateMap<TweetEntity, TweetViewModel>();
                //.ForMember(a => a.Author, a => a.MapFrom(b => b.Author.FirstName))
                //.ForMember(a => a.Head, a => a.MapFrom(b => b.Head))
                //.ForMember(a => a.Content, a => a.MapFrom(b => b.Content));
        }
        public static void Run()
        {
            Mapper.Initialize(a => {
                a.AddProfile<AutomapperTweetProfile>();
            });
        }
    }
}

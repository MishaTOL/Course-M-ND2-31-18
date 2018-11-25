using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.Models.ViewModel;

namespace Web.Infrastructure
{
    public class AutomapperTweetProfile : AutoMapper.Profile
    {
        public AutomapperTweetProfile()
        {
            CreateMap<TweetViewModel, Tweet>()
                .ForPath(a => a.Author.FirstName, a => a.MapFrom(b => b.Author));
            //.ForMember(a => a.Head, a => a.MapFrom(b => b.Head))
            //.ForMember(a => a.Content, a => a.MapFrom(b => b.Content))
            //.ForAllOtherMembers(a => a.Ignore());

            CreateMap<Tweet, TweetViewModel>();
                //.ForMember(a => a.Author, a => a.MapFrom(b => b.Author.FirstName))
                //.ForMember(a => a.Head, a => a.MapFrom(b => b.Head))
                //.ForMember(a => a.Content, a => a.MapFrom(b => b.Content));
        }
    }
}

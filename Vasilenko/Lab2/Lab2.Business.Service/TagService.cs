using Lab2.Business.Abstraction;
using Lab2.Business.Abstraction.Entity;
using Lab2.DataAccess.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagContract = Labs2.DataAccess.Entity.Tag;

namespace Lab2.Business.Service
{
    public class TagService : ITagService
    {
        private readonly IContextFactory contextFactory;

        public TagService (IContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public void AddTag(int postId, Tag tag)
        {
            using (var context = contextFactory.GetContext())
            {
                var post = context.PostsRepository.Where(x => x.Id == postId).FirstOrDefault();
                TagContract newTag = new TagContract { Id=tag.Id, Name=tag.Name };
                post.Tags.Add(newTag);
                context.Save();
            }
        }

        public int DeleteTag(int tagId, int postId)
        {        
                using (var context = contextFactory.GetContext())
                {
                    var tag = context.TagsRepository.Where(m => m.Id==tagId).FirstOrDefault();
                    var post = context.PostsRepository.Where(x => x.Id==postId).FirstOrDefault();
                    if (tag != null)
                    {
                        post.Tags.Remove(tag);
                        context.Save();
                    }
                    return post.Id;
                }       
        }

        public List<Tag> GetTags(int postId)
        {
            using (var context = contextFactory.GetContext())
            {
                var post = context.PostsRepository.Where(x => x.Id == postId).FirstOrDefault();
                var tags = post.Tags.Select(x => new Tag { Id = x.Id, Name =x.Name }).ToList();
                return tags;
            }
        }
    }
}

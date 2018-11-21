using Data.Contracts.Models;
using System.Data.Entity;
using System.Linq;

namespace Data.Repositories
{
    public class TagRepository : Repository<Tag>
    {
        public TagRepository(StudentBlogContext context) : base(context)
        {

        }

        public override void Update(Tag tag)
        {
            var oldTag = dbSet.Find(tag.Id);
            foreach (var post in tag.Posts)
            {
                var oldPost = context.Posts.Find(post.Id);
                if (!oldTag.Posts.Any(t => t.Id == oldPost.Id))
                {
                    oldTag.Posts.Add(oldPost);
                    context.Entry(oldPost).State = EntityState.Modified;
                }
            }

            context.Entry(oldTag).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}

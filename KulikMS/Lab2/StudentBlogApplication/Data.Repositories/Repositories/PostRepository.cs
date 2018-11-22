using Data.Contracts.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace Data.Repositories
{
    public class PostRepository : Repository<Post>
    {
        public PostRepository(StudentBlogContext context) : base(context)
        {

        }
        public override IEnumerable<Post> GetAll()
        {
            return dbSet.Include(s => s.Comments).Include(s => s.Tags);
        }

    }
}

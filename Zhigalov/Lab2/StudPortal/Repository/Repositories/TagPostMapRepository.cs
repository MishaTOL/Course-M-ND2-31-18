using Repository.Context;
using Repository.Interfaces;
using RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class TagPostMapRepository : IRepository<TagPostMap>
    {
        StudPortalContext context;

        public TagPostMapRepository()
        {
            context = new StudPortalContext();
        }

        public void Create(TagPostMap tagPost)
        {
            context.TagPosts.Add(tagPost);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.TagPosts.Remove(GetAll().Where(x => x.Id == id).FirstOrDefault());
            context.SaveChanges();
        }

        public IEnumerable<TagPostMap> GetAll()
        {
            return context.TagPosts;
        }
    }
}

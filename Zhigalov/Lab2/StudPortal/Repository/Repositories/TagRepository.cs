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
    public class TagRepository : ITagRepository
    {
        StudPortalContext context;

        public TagRepository()
        {
            context = new StudPortalContext();
        }

        public void Create(TagEntity tag)
        {
            var tagDB = GetAll().Where(x => x.Name == tag.Name).FirstOrDefault();
            if (tagDB == null)
            {
                context.Tags.Add(tag);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var tag = GetAll().Where(x => x.Id == id).FirstOrDefault();
            context.Tags.Remove(tag);
            context.SaveChanges();
        }

        public IEnumerable<TagEntity> GetAll()
        {
            return context.Tags;
        }
    }
}

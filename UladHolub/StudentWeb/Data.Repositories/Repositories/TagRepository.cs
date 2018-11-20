using Data.Contracts.Entities;
using Data.Contracts.Repositories;
using Data.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.Repositories.Repositories
{
    public class TagRepository : IRepository<Tag>
    {
        private StudentContext dataBase;

        public TagRepository(StudentContext context)
        {
            dataBase = context;
        }

        public IEnumerable<Tag> GetAll()
        {
            return dataBase.Tags;
        }

        public Tag Get(int id)
        {
            return dataBase.Tags.Find(id);
        }
        
        public void Create(Tag tag)
        {
            dataBase.Tags.Add(tag);
        }

        public void Update(Tag tag)
        {
            dataBase.Entry(tag).State = EntityState.Modified;
        }
        
        public IEnumerable<Tag> Find(Func<Tag, Boolean> predicate)
        {
            return dataBase.Tags.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Tag tag = dataBase.Tags.Find(id);

            if (tag != null) { dataBase.Tags.Remove(tag); }
        }
    }
}

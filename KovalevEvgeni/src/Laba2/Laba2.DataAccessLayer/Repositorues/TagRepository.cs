using Laba2.DataAccessLayer.EF;
using Laba2.DataAccessLayer.Entity;
using Laba2.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.DataAccessLayer.Repositorues
{
    public class TagRepository : IRepository<Tag>
    {
        private StudentDbContext dataBaseContext;

        public TagRepository(StudentDbContext dataBase)
        {
            dataBaseContext = dataBase;
        }

        public void Create(Tag item)
        {
            dataBaseContext.Tags.Add(item);
        }

        public void Delete(int recordId)
        {
            Tag record = GetRecord(recordId);
            if (record != null)
                dataBaseContext.Tags.Remove(record);
        }

        public IEnumerable<Tag> Find(Func<Tag, bool> predicate)
        {
            return dataBaseContext.Tags.Where(predicate).ToList();
        }

        public IEnumerable<Tag> GetAll()
        {
             return dataBaseContext.Tags;
        }

        public Tag GetRecord(int recordId)
        {
           return dataBaseContext.Tags.FirstOrDefault(s=>s.TagId== recordId);
        }

        public void Update(Tag item)
        {
            dataBaseContext.Entry(item).State = EntityState.Modified;
        }
    }
}

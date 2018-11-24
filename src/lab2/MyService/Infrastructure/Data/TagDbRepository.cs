using Lab2.Models.db;
using Lab2.MyService.Domain.Interface;
using Lab2.MyService.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.MyService.Infrastructure.Data
{
    public class TagDbRepository : ITagDbRepository<Tagdb>
    {
        DataContext db;

        public TagDbRepository()
        {
            db = new DataContext();
        }
        public void Create(Tagdb item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Tagdb Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tagdb> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tagdb> GetAll(int PostId)
        {
            return db.Tags.Where(s => s.PostId == PostId);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Tagdb item)
        {
            throw new NotImplementedException();
        }
    }
}
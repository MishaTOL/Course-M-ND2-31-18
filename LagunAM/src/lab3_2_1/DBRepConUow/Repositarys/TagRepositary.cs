using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DBModels.Models;
using DBRepConUow.Context;

namespace DBRepConUow.Repositarys
{
    public class TagRepositary : IRepositary<int, Tag>
    {
        ForumContext db;

        public TagRepositary(ForumContext db)
        {
            this.db = db;
        }

        public IEnumerable<Tag> GetAll()
        {
            return db.Tags.ToList();
        }

        public void Add(Tag Model)
        {
            db.Tags.Add(Model);
        }

        public void Delete(Tag Model)
        {
            db.Tags.Remove(Model);
        }

        public Tag Get(int Id)
        {
            return db.Tags.Find(Id);
        }

        public void Update(Tag Model)
        {
            db.Entry(Model).State = EntityState.Modified;
        }

        public Tag GetByName(string name)
        {
            return db.Tags.Where(p => p.Name == name).FirstOrDefault();
        }
    }
}
using Data.Contracts.Models;
using Data.Contracts.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.Repositories
{
    public class Repository<T> : IRepository<T> 
        where T : class, IEntity
    {
        protected readonly StudentBlogContext context;
        protected readonly IDbSet<T> dbSet;

        public Repository(StudentBlogContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
            context.Configuration.LazyLoadingEnabled = false;
        }
        public virtual T Add(T entity)
        {
            var createdEntity = dbSet.Add(entity);
            context.SaveChanges();
            return createdEntity;
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Update(T entity)
        {
            var oldEntity = dbSet.Find(entity.Id);
            var entry = context.Entry(oldEntity);
            entry.CurrentValues.SetValues(entity);
            entry.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}

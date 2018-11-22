using System.Collections.Generic;
using System.Linq;
using Data.Contracts.Models;
using Data.Contracts.Repositories;
using Domain.Contracts;
using Domain.Contracts.Services;

namespace Domain.Services
{
    public class Service<T, TEntity> : IService<T> 
        where T : class 
        where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> repository;
        private readonly IMapper<T, TEntity> mapper;
        public Service(IRepository<TEntity> repository, IMapper<T, TEntity> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public T Add(T entityView)
        {
            var entity = mapper.Map(entityView);
            var createdEntity = repository.Add(entity);
            return mapper.Map(createdEntity);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<T> GetAll()
        {
            return repository.GetAll().Select(e => mapper.Map(e));
        }

        public T GetById(int id)
        {
            var entitity = repository.GetById(id);
            return mapper.Map(entitity);
        }

        public void Update(T entityView)
        {
            var entity = mapper.Map(entityView);
            repository.Update(entity);
        }
    }
}

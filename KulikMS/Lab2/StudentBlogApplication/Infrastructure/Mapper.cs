using System.Collections.Generic;
using Domain.Contracts;

namespace Infrastructure
{
    public class Mapper<T, TEntity> : IMapper<T, TEntity>
        where T : class
        where TEntity : class
    {
        private readonly AutoMapper.IMapper mapper;

        public Mapper(AutoMapper.IMapper mapper)
        {
            this.mapper = mapper;
        }
        public T Map(TEntity entity) => mapper.Map<T>(entity);

        public TEntity Map(T entityView) => mapper.Map<TEntity>(entityView); 
    }
}

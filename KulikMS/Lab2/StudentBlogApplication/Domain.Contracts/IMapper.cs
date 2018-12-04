namespace Domain.Contracts
{
    public interface IMapper<T, TEntity> 
        where T : class
        where TEntity : class
    {
        T Map(TEntity entity);
        TEntity Map(T entityView);
    }
}

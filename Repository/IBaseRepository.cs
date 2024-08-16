namespace TestApiPitchOrder.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int entityId);

        Task<T> Insert(T entity);

        Task Update(T entity);

        Task Delete(int entityId);
    }
}

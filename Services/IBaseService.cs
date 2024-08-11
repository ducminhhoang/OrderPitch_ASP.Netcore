using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestApiPitchOrder.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int entityId);
        Task<T> Insert(T entity);
        Task Update(T entity);
        Task Delete(int entityId);
    }
}

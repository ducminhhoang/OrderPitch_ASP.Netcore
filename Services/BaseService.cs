using System.Collections.Generic;
using System.Threading.Tasks;
using TestApiPitchOrder.Repository;
using TestApiPitchOrder.Services;

namespace TestApiPitchOrder.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _baseRepository.GetAll();
        }

        public async Task<T> GetById(int entityId)
        {
            return await _baseRepository.GetById(entityId);
        }

        public async Task<T> Insert(T entity)
        {
            return await _baseRepository.Insert(entity);
        }

        public async Task Update(T entity)
        {
            await _baseRepository.Update(entity);
        }

        public async Task Delete(int entityId)
        {
            await _baseRepository.Delete(entityId);
        }
        protected virtual async Task ValidateCustom(T entity, bool isInsert)
        {

        }
    }
}

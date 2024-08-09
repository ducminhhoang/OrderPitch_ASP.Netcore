using OrderFootballPitch.Repository;
using System.Text;

namespace OrderFootballPitch.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        // Khai báo : khởi tạo interface BaseRepository
        IBaseRepository<T> _baseRepository;

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
            var entity = await _baseRepository.GetById(entityId);
            return entity;
        }

        protected virtual async Task ValidateCustom(T entity, bool isInsert)
        {

        }

        public async Task<T> Insert(T entity)
        {
            // Validate dữ liệu 
            ValidateCustom(entity, true);
            return await _baseRepository.Insert(entity);
        }

        public async Task Update(T entity)
        {
            ValidateCustom(entity, false);
            // số bản ghi bị thay đổi 
            await _baseRepository.Update(entity); ;
        }
        
        public async Task Delete(int entityId)
        {
            await _baseRepository.Delete(entityId);
        }
    }
}

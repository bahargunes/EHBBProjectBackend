

namespace ProjectBackend.Contracts.RepositoryInterfaces
{
    public interface IEmitterRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<T> UpdateAsync(T entity);
        Task<T?> GetByNameAsync(string name);
        Task<T?> GetBySpotNoAsync(string SpotNo);
    }
}

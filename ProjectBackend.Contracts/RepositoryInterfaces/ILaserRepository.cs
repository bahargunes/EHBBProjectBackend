

namespace ProjectBackend.Contracts.RepositoryInterfaces
{
    public interface ILaserRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<T> UpdateAsync(T entity);
    }
}

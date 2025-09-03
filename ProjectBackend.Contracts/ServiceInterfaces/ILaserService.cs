

namespace ProjectBackend.Contracts.ServiceInterfaces
{
    public interface ILaserService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T userDto);
        Task<T> UpdateAsync(int id, T userDto);
        Task<bool> DeleteAsync(int id);
    }
}



namespace ProjectBackend.Contracts.ServiceInterfaces
{
    public interface IEmitterService<T>
    {
            Task<IEnumerable<T>> GetAllAsync();
            Task<T> GetByIdAsync(int id);
            Task<T> AddAsync(T userDto);
            Task<T> UpdateAsync(int id, T userDto);
            Task<bool> DeleteAsync(int id);
            Task<T> GetByNameAsync(string emitterName);
            Task<T> GetBySpotNoAsync(string SpotNo);
            Task<bool> IsNameUniqueAsync(string name, int? excludeId );
            Task<bool> IsSpotNoUniqueAsync(string SpotNo, int? excludeId);



    }
}

using DesafioDotNetBaltaIO.Application.DTOs;

namespace DesafioDotNetBaltaIO.Application.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationDTO>> GetAsync();
        Task<LocationDTO> GetByCityAsync(string city);
        Task<LocationDTO> GetByStateAsync(string state);
        Task<LocationDTO> GetByIbgeAsync(string ibge);
        Task<int> AddAsync(LocationDTO location);
        Task<int> UpdateAsync(LocationDTO location);
        Task<int> RemoveAsync(string? id);
    }
}

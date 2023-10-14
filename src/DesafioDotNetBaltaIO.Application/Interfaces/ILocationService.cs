using DesafioDotNetBaltaIO.Application.DTOs;

namespace DesafioDotNetBaltaIO.Application.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationDTO>> GetAsync();
        Task<LocationDTO> GetByCityAsync(string city);
        Task<LocationDTO> GetByStateAsync(string state);
        Task<LocationDTO> GetByIbgeAsync(string ibge);
        Task<LocationDTO> AddAsync(LocationDTO location);
        Task UpdateAsync(LocationDTO location);
        Task RemoveAsync(string? id);
    }
}

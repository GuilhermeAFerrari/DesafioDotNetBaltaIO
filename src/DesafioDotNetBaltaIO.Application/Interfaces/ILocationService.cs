using DesafioDotNetBaltaIO.Application.DTOs;

namespace DesafioDotNetBaltaIO.Application.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationDTO>> GetLocationsAsync();
        Task<LocationDTO> GetByCityAsync(int? id);
        Task<LocationDTO> GetByStateAsync(int? id);
        Task<LocationDTO> GetByIbgeAsync(int? id);
        //Task AddAsync(CategoryDTO categoryDTO);
        //Task UpdateAsync(CategoryDTO categoryDTO);
        //Task RemoveAsync(int? id);
    }
}

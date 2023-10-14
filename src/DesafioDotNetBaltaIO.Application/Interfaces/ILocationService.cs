using DesafioDotNetBaltaIO.Application.DTOs;

namespace DesafioDotNetBaltaIO.Application.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationDTO>> GetLocationsAsync();
        Task<LocationDTO> GetLocationByCityAsync(string city);
        Task<LocationDTO> GetLocationByStateAsync(string state);
        Task<LocationDTO> GetLocationByIbgeAsync(string ibge);
        //Task AddAsync(CategoryDTO categoryDTO);
        //Task UpdateAsync(CategoryDTO categoryDTO);
        //Task RemoveAsync(int? id);
    }
}

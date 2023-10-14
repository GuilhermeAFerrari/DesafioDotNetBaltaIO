using DesafioDotNetBaltaIO.Domain.Entities;

namespace DesafioDotNetBaltaIO.Domain.Interfaces
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetLocationsAsync();
        Task<Location?> GetByCityAsync(string city);
        Task<Location?> GetByStateAsync(string state);
        Task<Location?> GetByIbgeAsync(string ibge);
        Task<Location> AddAsync(Location Location);
        Task UpdateAsync(Location Location);
        Task RemoveAsync(Location Location);
    }
}

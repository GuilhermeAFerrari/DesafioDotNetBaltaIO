using DesafioDotNetBaltaIO.Domain.Entities;
using DesafioDotNetBaltaIO.Domain.Interfaces;
using DesafioDotNetBaltaIO.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioDotNetBaltaIO.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly DesafioDotNetBaltaIOContext _dbContext;

        public LocationRepository(DesafioDotNetBaltaIOContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            return await _dbContext.Locations.ToListAsync();
        }

        public async Task<Location?> GetByCityAsync(string city)
        {
            return await _dbContext.Locations.FirstOrDefaultAsync(x => x.City == city);
        }

        public async Task<Location?> GetByStateAsync(string state)
        {
            return await _dbContext.Locations.FirstOrDefaultAsync(x => x.State == state);
        }

        public async Task<Location?> GetByIbgeAsync(string ibge)
        {
            return await _dbContext.Locations.FirstOrDefaultAsync(x => x.Id == ibge);
        }
    }
}

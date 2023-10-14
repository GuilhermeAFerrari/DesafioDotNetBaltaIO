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

        public async Task<IEnumerable<Location>> GetLocationsAsync() =>  await _dbContext.Ibge.ToListAsync();

        public async Task<Location?> GetByCityAsync(string city) => await _dbContext.Ibge.FirstOrDefaultAsync(x => x.City == city);

        public async Task<Location?> GetByStateAsync(string state) => await _dbContext.Ibge.FirstOrDefaultAsync(x => x.State == state);

        public async Task<Location?> GetByIbgeAsync(string ibge) => await _dbContext.Ibge.FirstOrDefaultAsync(x => x.Id == ibge);

        public async Task<Location> AddAsync(Location location)
        {
            _dbContext.Add(location);
            await _dbContext.SaveChangesAsync();
            return location;
        }

        public async Task UpdateAsync(Location Location)
        {
            _dbContext.Update(Location);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Location Location)
        {
            _dbContext.Remove(Location);
            await _dbContext.SaveChangesAsync();
        }
    }
}

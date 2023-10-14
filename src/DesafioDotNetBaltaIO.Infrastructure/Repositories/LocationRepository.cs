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

        public async Task<IEnumerable<Location>> GetLocationsAsync() =>
            await _dbContext.Ibge
            .AsNoTracking()
            .ToListAsync();

        public async Task<Location?> GetByCityAsync(string city) =>
            await _dbContext.Ibge
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.City == city);

        public async Task<Location?> GetByStateAsync(string state) =>
            await _dbContext.Ibge
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.State == state);

        public async Task<Location?> GetByIbgeAsync(string ibge) =>
            await _dbContext.Ibge
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == ibge);

        public async Task<int> AddAsync(Location location)
        {
            _dbContext.Add(location);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Location Location)
        {
            _dbContext.Update(Location);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(Location Location)
        {
            _dbContext.Remove(Location);
            return await _dbContext.SaveChangesAsync();
        }
    }
}

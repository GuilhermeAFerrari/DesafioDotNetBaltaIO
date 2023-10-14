using AutoMapper;
using DesafioDotNetBaltaIO.Application.DTOs;
using DesafioDotNetBaltaIO.Application.Interfaces;
using DesafioDotNetBaltaIO.Domain.Interfaces;

namespace DesafioDotNetBaltaIO.Application.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationService(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<LocationDTO>> GetLocationsAsync()
        {
            var locations = await _locationRepository.GetLocationsAsync();
            return _mapper.Map<IEnumerable<LocationDTO>>(locations);
        }

        public Task<LocationDTO> GetByCityAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<LocationDTO> GetByStateAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<LocationDTO> GetByIbgeAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}

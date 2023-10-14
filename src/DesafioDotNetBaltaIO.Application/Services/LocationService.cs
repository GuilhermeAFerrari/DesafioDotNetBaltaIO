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

        public async Task<LocationDTO> GetLocationByCityAsync(string city)
        {
            return _mapper
                .Map<LocationDTO>(
                    await _locationRepository.GetByCityAsync(city)
                );
        }

        public async Task<LocationDTO> GetLocationByStateAsync(string state)
        {
            return _mapper
                .Map<LocationDTO>(
                    await _locationRepository.GetByStateAsync(state)
                );
        }

        public async Task<LocationDTO> GetLocationByIbgeAsync(string ibge)
        {
            return _mapper
                .Map<LocationDTO>(
                    await _locationRepository.GetByIbgeAsync(ibge)
                );
        }
    }
}

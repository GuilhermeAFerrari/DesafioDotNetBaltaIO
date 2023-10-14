using AutoMapper;
using DesafioDotNetBaltaIO.Application.DTOs;
using DesafioDotNetBaltaIO.Application.Interfaces;
using DesafioDotNetBaltaIO.Domain.Entities;
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

        public async Task<IEnumerable<LocationDTO>> GetAsync()
        {
            var locations = await _locationRepository.GetLocationsAsync();
            return _mapper.Map<IEnumerable<LocationDTO>>(locations);
        }

        public async Task<LocationDTO> GetByCityAsync(string city)
        {
            return _mapper
                .Map<LocationDTO>(
                    await _locationRepository.GetByCityAsync(city)
                );
        }

        public async Task<LocationDTO> GetByStateAsync(string state)
        {
            return _mapper
                .Map<LocationDTO>(
                    await _locationRepository.GetByStateAsync(state)
                );
        }

        public async Task<LocationDTO> GetByIbgeAsync(string ibge)
        {
            return _mapper
                .Map<LocationDTO>(
                    await _locationRepository.GetByIbgeAsync(ibge)
                );
        }

        public async Task<LocationDTO> AddAsync(LocationDTO location)
        {
            var locationEntity = _mapper.Map<Location>(location);
            await _locationRepository.AddAsync(locationEntity);
            return location;
        }

        public async Task UpdateAsync(LocationDTO location)
        {
            var locationEntity = _mapper.Map<Location>(location);
            await _locationRepository.UpdateAsync(locationEntity);
        }

        public async Task RemoveAsync(string? id)
        {
            var locationEntity = await _locationRepository.GetByIbgeAsync(id);
            await _locationRepository.RemoveAsync(locationEntity);
        }
    }
}

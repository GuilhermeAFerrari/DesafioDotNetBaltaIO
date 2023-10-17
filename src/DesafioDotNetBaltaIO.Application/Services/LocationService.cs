using AutoMapper;
using DesafioDotNetBaltaIO.Application.DTOs;
using DesafioDotNetBaltaIO.Application.Interfaces;
using DesafioDotNetBaltaIO.Domain.Entities;
using DesafioDotNetBaltaIO.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

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

        public async Task<IResult> GetAsync()
        {
            var result = _mapper
                .Map<IEnumerable<LocationDTO>>(
                    await _locationRepository.GetLocationsAsync()
            );

            return result is IEnumerable<LocationDTO> location
            ? Results.Ok(location)
            : Results.NotFound();
        }

        public async Task<IResult> GetByCityAsync(string city)
        {
            var result = _mapper
                .Map<LocationDTO>(
                    await _locationRepository.GetByCityAsync(city)
                );

            return result is LocationDTO location
            ? Results.Ok(location)
            : Results.NotFound();
        }

        public async Task<IResult> GetByStateAsync(string state)
        {
            var result = _mapper
                .Map<IEnumerable<LocationDTO>>(
                    await _locationRepository.GetByStateAsync(state)
            );

            return result is IEnumerable<LocationDTO> location
            ? Results.Ok(location)
            : Results.NotFound();
        }

        public async Task<IResult> GetByIbgeAsync(string ibge)
        {
            var result = _mapper
                .Map<LocationDTO>(
                    await _locationRepository.GetByIbgeAsync(ibge)
            );

            return result is LocationDTO location
            ? Results.Ok(location)
            : Results.NotFound();
        }

        public async Task<IResult> AddAsync(LocationDTO location)
        {
            var locationEntity = _mapper.Map<Location>(location);
            var result = await _locationRepository.AddAsync(locationEntity);

            return result > 0
            ? Results.CreatedAtRoute("GetLocationByIbge", new { ibge = location.Id }, location)
            : Results.BadRequest("An error ocurred while saving the record");
        }

        public async Task<IResult> UpdateAsync(LocationDTO location)
        {
            var locationFromDatabase = await _locationRepository.GetByIbgeAsync(location.Id);
            if (locationFromDatabase is null) return Results.NotFound();

            var locationEntity = _mapper.Map<Location>(location);
            var result = await _locationRepository.UpdateAsync(locationEntity);

            return result > 0
            ? Results.NoContent()
            : Results.BadRequest("An error ocurred while saving the record");
        }

        public async Task<IResult> RemoveAsync(string id)
        {
            var locationEntity = await _locationRepository.GetByIbgeAsync(id);
            if (locationEntity is null) return Results.NotFound();

            var result = await _locationRepository.RemoveAsync(locationEntity);

            return result > 0
            ? Results.NoContent()
            : Results.BadRequest("An error ocurred while saving the record");
        }
    }
}

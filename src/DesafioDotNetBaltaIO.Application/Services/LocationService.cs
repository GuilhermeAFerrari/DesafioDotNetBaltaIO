﻿using AutoMapper;
using DesafioDotNetBaltaIO.Application.DTOs;
using DesafioDotNetBaltaIO.Application.Interfaces;
using DesafioDotNetBaltaIO.Domain.Entities;
using DesafioDotNetBaltaIO.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using MiniValidation;

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
            if (!MiniValidator.TryValidate(location, out var errors))
                return Results.ValidationProblem(errors);

            var recordExists = await RecordAlreadyExists(location);
            if (recordExists is not null) return Results.BadRequest(recordExists);

            var locationEntity = _mapper.Map<Location>(location);
            var result = await _locationRepository.AddAsync(locationEntity);

            return result > 0
            ? Results.CreatedAtRoute("GetLocationByIbge", new { ibge = location.Id }, location)
            : Results.BadRequest("An error ocurred while saving the record");
        }

        public async Task<IResult> UpdateAsync(LocationDTO location)
        {
            if (!MiniValidator.TryValidate(location, out var errors))
                return Results.ValidationProblem(errors);

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

        private async Task<string?> RecordAlreadyExists(LocationDTO location)
        { 
            if (await _locationRepository.GetByIbgeAsync(location.Id) is not null)
                return $"The location with IBGE {location.Id} already exists on database";

            if (await _locationRepository.GetByCityAsync(location.City) is not null)
                return $"The location with City {location.City} already exists on database";

            return null;
        }
    }
}

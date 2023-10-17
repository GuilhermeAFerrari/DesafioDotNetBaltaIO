using DesafioDotNetBaltaIO.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace DesafioDotNetBaltaIO.Application.Interfaces
{
    public interface ILocationService
    {
        Task<IResult> GetAsync();
        Task<IResult> GetByCityAsync(string city);
        Task<IResult> GetByStateAsync(string state);
        Task<IResult> GetByIbgeAsync(string ibge);
        Task<IResult> AddAsync(LocationDTO location);
        Task<IResult> UpdateAsync(LocationDTO location);
        Task<IResult> RemoveAsync(string id);
    }
}

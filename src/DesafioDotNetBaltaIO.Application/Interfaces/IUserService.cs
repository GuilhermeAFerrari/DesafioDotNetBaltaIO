using DesafioDotNetBaltaIO.Application.DTOs;
using DesafioDotNetBaltaIO.Domain.Entities;

namespace DesafioDotNetBaltaIO.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByEmailAndPasswordAsync(UserDTO user);
        Task<int> AddAsync(UserDTO user);
    }
}

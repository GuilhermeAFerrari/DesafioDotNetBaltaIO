using DesafioDotNetBaltaIO.Domain.Entities;

namespace DesafioDotNetBaltaIO.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAndPasswordAsync(User user);
        Task<int> AddAsync(User user);
    }
}

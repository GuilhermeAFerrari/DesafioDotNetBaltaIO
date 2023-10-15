using DesafioDotNetBaltaIO.Domain.Entities;

namespace DesafioDotNetBaltaIO.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAndPassword(string email, string password);
    }
}

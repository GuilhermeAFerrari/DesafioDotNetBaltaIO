using DesafioDotNetBaltaIO.Domain.Entities;

namespace DesafioDotNetBaltaIO.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}

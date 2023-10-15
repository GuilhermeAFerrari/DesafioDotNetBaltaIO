using DesafioDotNetBaltaIO.Application.DTOs;
using DesafioDotNetBaltaIO.Application.Interfaces;
using DesafioDotNetBaltaIO.Domain.Entities;
using DesafioDotNetBaltaIO.Domain.Interfaces;

namespace DesafioDotNetBaltaIO.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetByEmailAndPasswordAsync(UserDTO user)
        {
            return await _userRepository.GetByEmailAndPassword(user.Email, user.Password);
        }
    }
}

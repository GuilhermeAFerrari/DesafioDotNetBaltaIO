using AutoMapper;
using DesafioDotNetBaltaIO.Application.DTOs;
using DesafioDotNetBaltaIO.Application.Interfaces;
using DesafioDotNetBaltaIO.Domain.Entities;
using DesafioDotNetBaltaIO.Domain.Interfaces;

namespace DesafioDotNetBaltaIO.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User?> GetByEmailAndPasswordAsync(UserDTO user)
        {
            var userEntity = _mapper.Map<User>(user);
            return await _userRepository.GetByEmailAndPasswordAsync(userEntity);
        }

        public async Task<int> AddAsync(UserDTO user)
        {
            var userEntity = _mapper.Map<User>(user);
            return await _userRepository.AddAsync(userEntity);
        }
    }
}

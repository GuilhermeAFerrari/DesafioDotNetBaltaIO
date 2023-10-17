using DesafioDotNetBaltaIO.Domain.Entities;
using DesafioDotNetBaltaIO.Domain.Interfaces;
using DesafioDotNetBaltaIO.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioDotNetBaltaIO.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DesafioDotNetBaltaIOContext _dbContext;

        public UserRepository(DesafioDotNetBaltaIOContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetByEmailAndPasswordAsync(User user)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x =>
                x.Email.ToLower() == user.Email.ToLower() &&
                x.Password == user.Password
            );
        }

        public async Task<int> AddAsync(User user)
        {
            _dbContext.Add(user);
            return await _dbContext.SaveChangesAsync();
        }
    }
}

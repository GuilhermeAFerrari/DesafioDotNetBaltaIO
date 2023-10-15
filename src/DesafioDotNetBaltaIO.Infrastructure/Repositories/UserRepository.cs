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

        public async Task<User?> GetByEmailAndPassword(string email, string password)
        {
            return await _dbContext.User.FirstOrDefaultAsync(
                x => string.Equals(x.Email, email, StringComparison.CurrentCultureIgnoreCase) &&
                x.Password.ToLower() == password
            );
        }
    }
}

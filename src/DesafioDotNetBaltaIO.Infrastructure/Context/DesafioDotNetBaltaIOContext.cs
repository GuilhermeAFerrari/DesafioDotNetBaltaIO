using DesafioDotNetBaltaIO.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioDotNetBaltaIO.Infrastructure.Context
{
    public class DesafioDotNetBaltaIOContext : DbContext
    {
        public DesafioDotNetBaltaIOContext(DbContextOptions<DesafioDotNetBaltaIOContext> options) : base(options) { }

        public DbSet<Location> Locations { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Zummit.Auth.Models;

namespace Zummit.Auth.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente>? Clientes { get; set; }

    }
}

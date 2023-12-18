using Microsoft.EntityFrameworkCore;
using Zummit.ControleFinanceiro.API.Models.Banco;

namespace Zummit.Conta.Data
{
    public class ContaDbContext : DbContext
    {
        public ContaDbContext(DbContextOptions<ContaDbContext> options) : base(options) { }

        public DbSet<ContaBancaria>? ContaBancarias { get; set; }
    }
}

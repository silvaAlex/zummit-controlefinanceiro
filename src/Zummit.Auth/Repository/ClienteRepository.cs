using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Zummit.Auth.Data;
using Zummit.Auth.Models;
using Zummit.Auth.ViewModels;

namespace Zummit.Auth.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        AppDbContext dbContext;

        public ClienteRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(Cliente cliente)
        {
            var data = dbContext.Clientes?.Add(cliente);
            if (data != null)
            {
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Guid clienteId)
        {
            var cliente = await GetAsync(clienteId);

            if(cliente != null)
            {
                dbContext.Clientes?.Remove(cliente);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Cliente?>> GetAllAsync()
        {
#pragma warning disable CS8602 // Desreferência de uma referência possivelmente nula.
            var clientes = await dbContext.Clientes?.ToListAsync();
#pragma warning restore CS8602 // Desreferência de uma referência possivelmente nula.
            return clientes;
        }

        public async Task<Cliente?> GetAsync(Guid clienteId)
        {
            var cliente = await dbContext.Clientes?.SingleOrDefaultAsync(x => x.Id == clienteId)!;
            return cliente;
        }

        public async Task UpdateAsync(Guid clienteId, ClienteVM clienteVM)
        {
            var cliente = await GetAsync(clienteId);

            if(cliente != null)
            {
                cliente.Nome = clienteVM.Nome;
                dbContext.Clientes?.Update(cliente);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}

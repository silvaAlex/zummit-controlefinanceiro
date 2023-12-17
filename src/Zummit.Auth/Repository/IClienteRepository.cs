using System.Linq.Expressions;
using Zummit.Auth.Models;
using Zummit.Auth.ViewModels;

namespace Zummit.Auth.Repository
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente?>> GetAllAsync();
        Task<Cliente?> GetAsync(Guid clienteId);
        Task CreateAsync(Cliente cliente);
        Task UpdateAsync(Guid clienteId, ClienteVM cliente);
        Task DeleteAsync(Guid clienteId);
    }
}

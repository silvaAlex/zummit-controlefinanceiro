using Zummit.Auth.Models;
using Zummit.Auth.ViewModels;

namespace Zummit.Auth.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente?>> GetAllAsync();
        Task<Cliente?> GetAsync(Guid clienteId);
        Task CreateAsync(Cliente cliente);
        Task UpdateAsync(Guid clienteId, ClienteVM clienteVM);
        Task DeleteAsync(Guid clienteId);
    }
}

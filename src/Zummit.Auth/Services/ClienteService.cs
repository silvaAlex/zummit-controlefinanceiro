using Zummit.Auth.Models;
using Zummit.Auth.Repository;
using Zummit.Auth.ViewModels;

namespace Zummit.Auth.Services
{
    public class ClienteService : IClienteService
    {
        readonly IClienteRepository clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public Task CreateAsync(Cliente cliente) => clienteRepository.CreateAsync(cliente);

        public Task DeleteAsync(Guid clienteId) => clienteRepository.DeleteAsync(clienteId);

        public Task<IEnumerable<Cliente?>> GetAllAsync() => clienteRepository.GetAllAsync();
      
        public Task<Cliente?> GetAsync(Guid clienteId) => clienteRepository.GetAsync(clienteId);

        public Task UpdateAsync(Guid clienteId, ClienteVM clienteVM) => clienteRepository.UpdateAsync(clienteId, clienteVM);
    }
}

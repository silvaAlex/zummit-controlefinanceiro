using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Zummit.Auth.Models;
using Zummit.Auth.Services;
using Zummit.Auth.ViewModels;

namespace Zummit.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        readonly IClienteService clienteService;

        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IEnumerable<Cliente?>> GetAllAsync()
        {
           return await clienteService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Cliente?> GetClienteAsync(Guid id)
        {
            return await clienteService.GetAsync(id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await clienteService.DeleteAsync(id);
        }

        [HttpPost("{id}")]
        public async Task UpdateCliente([FromBody] ClienteVM clienteVM, Guid clienteId)
        {
            await clienteService.UpdateAsync(clienteId, clienteVM);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Zummit.Conta.Repositories;
using Zummit.ControleFinanceiro.API.Models.Banco;

namespace Zummit.Conta.Services
{
    public class ContaBancariaService : IContaBancariaService
    {
        readonly IContaBancariaRepository contaBancariaRepository;

        public ContaBancariaService(IContaBancariaRepository contaBancariaRepository)
        {
            this.contaBancariaRepository = contaBancariaRepository;
        }

        public Task<ContaBancaria> ObterContaBancaria(Guid? clienteId) => contaBancariaRepository.ObterContaBancaria(clienteId);

        public Task Depositar(Guid? clienteId, double quantia) => contaBancariaRepository.Depositar(clienteId, quantia);

        public string RetornaDataAberturaFormatada(Guid? clienteId) => contaBancariaRepository.RetornaDataAberturaFormatada(clienteId);

        public string RetornaSaldoFormatado(Guid? clienteId) => contaBancariaRepository.RetornaSaldoFormatado(clienteId);
        
        public Task Sacar(Guid? clienteId,double quantia) => contaBancariaRepository.Sacar(clienteId, quantia);
        
    }
}

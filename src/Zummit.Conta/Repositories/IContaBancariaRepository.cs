using Zummit.ControleFinanceiro.API.Models.Banco;

namespace Zummit.Conta.Repositories
{
    public interface IContaBancariaRepository
    {
        Task Sacar(Guid? clienteId,double quantia);
        Task Depositar(Guid? clienteId, double quantia);
        string RetornaSaldoFormatado(Guid? clienteId);
        string RetornaDataAberturaFormatada(Guid? clienteId);
        Task<ContaBancaria> ObterContaBancaria(Guid? clienteId);
    }
}

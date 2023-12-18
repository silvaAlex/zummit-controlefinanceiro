using Zummit.Conta.Data;
using Zummit.ControleFinanceiro.API.Models.Banco;

namespace Zummit.Conta.Repositories
{
    public class ContaBancariaRepository : IContaBancariaRepository
    {
        readonly ContaDbContext dbContext;

        public ContaBancariaRepository(ContaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<ContaBancaria> ObterContaBancaria(Guid? clienteId)
        {
            var contaBancaria = dbContext.ContaBancarias?.Find(clienteId);
            return Task.FromResult(contaBancaria ?? new ContaBancaria());
        }

        public async Task Depositar(Guid? clienteId, double quantia)
        {
            var contaBancaria = await ObterContaBancaria(clienteId);

            var saldo = contaBancaria.ObterSaldo();

            if(quantia > 0)
            {
                saldo += quantia;
                contaBancaria.AtualizarSaldo(saldo);
            }
            else
            {
                throw new InvalidOperationException("Quantia insuficiente para deposito.");
            }

            dbContext.ContaBancarias?.Add(contaBancaria);
            await dbContext.SaveChangesAsync();
        }

        public async Task Sacar(Guid? clienteId, double quantia)
        {
            var contaBancaria = dbContext.ContaBancarias?.Find(clienteId);

            if (contaBancaria != null)
            {
                var saldo = contaBancaria.ObterSaldo();
                if (saldo - quantia >= 0)
                {
                    saldo -= quantia;
                    contaBancaria.AtualizarSaldo(saldo);
                }
                else
                {
                    throw new InvalidOperationException("Saldo insuficiente para saque.");
                }
                dbContext.ContaBancarias?.Update(contaBancaria);
                await dbContext.SaveChangesAsync();
            }
        }

        public string RetornaDataAberturaFormatada(Guid? clienteId)
        {
            var contaBancaria = dbContext.ContaBancarias?.Find(clienteId);
            return contaBancaria != null ? contaBancaria.RetornaDataAberturaFormatada() : string.Empty;
        }

        public string RetornaSaldoFormatado(Guid? clienteId)
        {
            var contaBancaria = dbContext.ContaBancarias?.Find(clienteId);
            return contaBancaria != null ? contaBancaria.RetornaSaldoFormatado() : string.Empty;
        }
    }
}

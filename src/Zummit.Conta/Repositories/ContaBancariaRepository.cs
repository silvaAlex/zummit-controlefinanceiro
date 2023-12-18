using System.Drawing;
using Zummit.Conta.Data;
using Zummit.ControleFinanceiro.API.Models.Banco;

namespace Zummit.Conta.Repositories
{
    public class ContaBancariaRepository : IContaBancariaRepository
    {
        readonly ContaDbContext dbContext;
        readonly ContaBancaria contaBancaria;

        public ContaBancariaRepository(ContaDbContext dbContext)
        {
            this.dbContext = dbContext;
            contaBancaria = new();
        }

        public async Task Depositar(double quantia)
        {
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

        public async Task Sacar(double quantia)
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

        public string RetornaDataAberturaFormatada()
        {
            return contaBancaria.RetornaDataAberturaFormatada();
        }

        public string RetornaSaldoFormatado()
        {
            return contaBancaria.RetornaSaldoFormatado();
        }
    }
}

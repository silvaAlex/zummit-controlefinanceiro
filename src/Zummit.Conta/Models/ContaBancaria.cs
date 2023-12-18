using System.Globalization;

namespace Zummit.ControleFinanceiro.API.Models.Banco
{
    public record ContaBancaria
    {
        private double saldo = 0.0;
        private readonly DateTime dataAbertura;

        public ContaBancaria()
        {
            saldo = 0.0;
            dataAbertura = DateTime.Now;
        }

        public string RetornaSaldoFormatado()
        {
            return string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", saldo);
        }

        public double ObterSaldo()
        {
            return saldo;
        }

        public void AtualizarSaldo(double quantia)
        {
            saldo = quantia;
        }

        public string RetornaDataAberturaFormatada()
        {
            return dataAbertura.ToString("dd/mm/yyyy");
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Zummit.ControleFinanceiro.API.Models.Banco
{
    public record ContaBancaria
    {
        [Key]
        public Guid ClienteId { get; set; }
        public double Saldo { get; private set; }

        private readonly DateTime dataAbertura;

        public ContaBancaria()
        {
            Saldo = 0.0;
            ClienteId = Guid.NewGuid();
            dataAbertura = DateTime.Now;
        }

        public string RetornaSaldoFormatado()
        {
            return string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", Saldo);
        }

        public double ObterSaldo()
        {
            return Saldo;
        }

        public void AtualizarSaldo(double saldo)
        {
            Saldo = saldo;
        }

        public string RetornaDataAberturaFormatada()
        {
            return dataAbertura.ToString("dd/mm/yyyy");
        }
    }
}

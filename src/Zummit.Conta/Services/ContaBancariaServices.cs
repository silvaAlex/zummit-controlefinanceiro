using Zummit.Conta.Repositories;

namespace Zummit.Conta.Services
{
    public class ContaBancariaServices : IContaBancariaService
    {
        readonly IContaBancariaRepository contaBancariaRepository;

        public ContaBancariaServices(IContaBancariaRepository contaBancariaRepository)
        {
            this.contaBancariaRepository = contaBancariaRepository;
        }

        public Task Depositar(double quantia) => contaBancariaRepository.Depositar(quantia);

        public string RetornaDataAberturaFormatada() => contaBancariaRepository.RetornaDataAberturaFormatada();

        public string RetornaSaldoFormatado() => contaBancariaRepository.RetornaSaldoFormatado();
        
        public Task Sacar(double quantia) => contaBancariaRepository.Sacar(quantia);
        
    }
}

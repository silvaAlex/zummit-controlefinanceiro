namespace Zummit.Conta.Services
{
    public interface IContaBancariaService
    {
        Task Sacar(double quantia);
        Task Depositar(double quantia);
        string RetornaSaldoFormatado();
        string RetornaDataAberturaFormatada();
    }
}

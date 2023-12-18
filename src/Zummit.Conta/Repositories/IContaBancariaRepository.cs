namespace Zummit.Conta.Repositories
{
    public interface IContaBancariaRepository
    {
        Task Sacar(double quantia);
        Task Depositar(double quantia);
        string RetornaSaldoFormatado();
        string RetornaDataAberturaFormatada();
    }
}

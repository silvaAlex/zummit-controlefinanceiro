namespace Zummit.Auth.DTO.Response
{
    public class CadastroUsuarioResponse
    {
        public bool Success { get; private set; }
        public List<string> Erros { get; private set; }

        public CadastroUsuarioResponse()
        {
            Erros = new List<string>();
        }

        public CadastroUsuarioResponse(bool sucesso = true) : this()
        {
            Success = sucesso;
        }

        public void AddErros(IEnumerable<string> erros) => Erros.AddRange(erros);

    }
}

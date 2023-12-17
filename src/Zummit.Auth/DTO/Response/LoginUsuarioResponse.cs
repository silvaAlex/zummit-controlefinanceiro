using System.Text.Json.Serialization;

namespace Zummit.Auth.DTO.Response
{
    public class LoginUsuarioResponse
    {
        public bool Sucesso => Erros.Count == 0;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AccessToken { get; private set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? RefreshToken { get; private set; }

        public List<string> Erros { get; private set; }

        public LoginUsuarioResponse()
        {
            Erros = new List<string>();
        }

        public LoginUsuarioResponse(bool sucesso, string accessToken, string refreshToken) : this()
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public void AddErro(string erro) =>
            Erros.Add(erro);

        public void AddErros(IEnumerable<string> erros) =>
            Erros.AddRange(erros);
    }
}
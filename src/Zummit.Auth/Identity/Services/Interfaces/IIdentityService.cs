using System.Threading.Tasks;
using Zummit.Auth.DTO.Request;
using Zummit.Auth.DTO.Response;

namespace Zummit.Auth.Identity.Services.Interfaces
{
    public interface IIdentityService<TRequest, TResponse> { }

    public interface ICadastroService : IIdentityService<CadastroUsuarioRequest, CadastroUsuarioResponse>
    {
        Task<CadastroUsuarioResponse> CadastrarUsuario(CadastroUsuarioRequest cadastroUsuario);
    }

    public interface ILoginService : IIdentityService<LoginUsuarioRequest, LoginUsuarioResponse>
    {
        Task<LoginUsuarioResponse> CadastrarUsuario(LoginUsuarioRequest loginRequest);
    }
}

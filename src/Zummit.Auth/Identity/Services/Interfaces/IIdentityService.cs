using Zummit.Auth.DTO.Request;
using Zummit.Auth.DTO.Response;

namespace Zummit.Auth.Identity.Services.Interfaces
{
    public interface IIdentityService 
    { 
        Task<CadastroUsuarioResponse> CadastrarUsuario(CadastroUsuarioRequest cadastroUsuario);
 
        Task<LoginUsuarioResponse> LoginUsuario(LoginUsuarioRequest loginRequest);
    }
}

using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Zummit.Auth.DTO.Request;
using Zummit.Auth.DTO.Response;
using Zummit.Auth.Identity.Jwt;
using Zummit.Auth.Identity.Services.Interfaces;

namespace Zummit.Auth.Identity.Services
{
    public class IdentityService : ICadastroService, ILoginService
    {
        readonly UserManager<IdentityUser> userManager;
        readonly SignInManager<IdentityUser> signInManager;
        readonly JwtOptions jwtOptions;

        public IdentityService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, JwtOptions jwtOptions)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.jwtOptions = jwtOptions;
        }

        public async Task<CadastroUsuarioResponse> CadastrarUsuario(CadastroUsuarioRequest cadastroUsuario)
        {
            var identityUser = new IdentityUser
            {
                UserName = cadastroUsuario.Email,
                Email = cadastroUsuario.Email,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(identityUser);
            if(result.Succeeded)
                    await userManager.SetLockoutEnabledAsync(identityUser, false);

            var usuarioCadastroResponse = new CadastroUsuarioResponse(result.Succeeded);
            if (!result.Succeeded && result.Errors.Any())
                usuarioCadastroResponse.AddErros(result.Errors.Select(r => r.Description));

            return usuarioCadastroResponse;
        }

        public async Task<LoginUsuarioResponse> LoginUsuario(LoginUsuarioRequest loginUsuario)
        {
            var result = await signInManager.PasswordSignInAsync(loginUsuario.Email, loginUsuario.Senha, false, true);

            if (result.Succeeded)
                return await GerarCredenciais(loginUsuario.Email);

            var usuarioLoginResponse = new LoginUsuarioResponse();
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                    usuarioLoginResponse.AddErro("Essa conta está bloqueada");
                else if (result.IsNotAllowed)
                    usuarioLoginResponse.AddErro("Essa conta não tem permissão para fazer login");
                else if (result.RequiresTwoFactor)
                    usuarioLoginResponse.AddErro("É necessário confirmar o login no seu segundo fator de autenticação");
                else
                    usuarioLoginResponse.AddErro("Usuário ou senha estão incorretos");
            }

            return usuarioLoginResponse;
        }

        private async Task<LoginUsuarioResponse> GerarCredenciais(string? email)
        {
            var user = await userManager.FindByEmailAsync(email);
            var accessTokenClaims = await ObterClaims(user, adicionarClaimsUsuario: true);
            var refreshTokenClaims = await ObterClaims(user, adicionarClaimsUsuario: false);

            var dataExpiracaoAccessToken = DateTime.Now.AddSeconds(jwtOptions.Expiration);
            var dataExpiracaoRefreshToken = DateTime.Now.AddSeconds(jwtOptions.RefreshTokenExpiration);

            var accessToken = GerarToken(accessTokenClaims, dataExpiracaoAccessToken);
            var refreshToken = GerarToken(refreshTokenClaims, dataExpiracaoRefreshToken);

            return new LoginUsuarioResponse
            (
                sucesso: true,
                accessToken: accessToken,
                refreshToken: refreshToken
            );
        }

        private async Task<IList<Claim>> ObterClaims(IdentityUser user, bool adicionarClaimsUsuario)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString())
            };

            if (adicionarClaimsUsuario)
            {
                var userClaims = await userManager.GetClaimsAsync(user);
                var roles = await userManager.GetRolesAsync(user);

                claims.AddRange(userClaims);

                foreach (var role in roles)
                    claims.Add(new Claim("role", role));
            }

            return claims;
        }

        private string GerarToken(IEnumerable<Claim> accessTokenClaims, DateTime dataExpiracaoAccessToken)
        {
            var jwt = new JwtSecurityToken(
               issuer: jwtOptions.Issuer,
               audience: jwtOptions.Audience,
               claims: accessTokenClaims,
               notBefore: DateTime.Now,
               expires: dataExpiracaoAccessToken,
               signingCredentials: jwtOptions.SigningCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}

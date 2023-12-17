using Microsoft.IdentityModel.Tokens;

namespace Zummit.Auth.Identity.Jwt
{
    public class JwtOptions
    {
        public int Expiration { get; set; } = 1;
        public string Issuer { get; set; } = "Zummit.Auth.Identity";
        public string Audience { get; set; } = "Api";

        public SigningCredentials? SigningCredentials { get; set; }

        public int RefreshTokenExpiration { get; set; } = 30;
        public RefreshTokenType RefreshTokenType { get; set; } = RefreshTokenType.OneTime;
    }
}

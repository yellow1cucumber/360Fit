using Domain.Core.Users;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Auth.Services
{
    public class AccessTokenService
    {
        private readonly IConfiguration configuration;
        public AccessTokenService(IConfiguration configuration)
            => this.configuration = configuration;

        public string GenerateToken(User user)
        {
            var handler = new JwtSecurityTokenHandler();
            var privateKey = this.configuration["Security:PrivateKey"]
                ?? throw new Exception("ERROR: private key not found");
            var key = Encoding.ASCII.GetBytes(privateKey);
            var credentials = new SigningCredentials
                (
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = this.GenerateClaims(user),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = credentials
            };

            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        private ClaimsIdentity GenerateClaims(User user) {
            var claims = new ClaimsIdentity();

            var payload = new Claim[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Credentials.PhoneNumber),
                new Claim(ClaimTypes.Role, user.Credentials.Role.ToString())
            };

            claims.AddClaims(payload);
            return claims;
        }
    }
}

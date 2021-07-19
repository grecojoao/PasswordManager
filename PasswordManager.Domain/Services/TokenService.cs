using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PasswordManager.Domain.Entities;
using PasswordManager.Domain.Services.Contracts;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration) =>
            _configuration = configuration;

        public Task<UserToken> GenerateAsync(User user, CancellationToken cancellationToken = default)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = (_configuration.GetSection("Secret").Value);
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenExpirationDate = DateTime.UtcNow.ToLocalTime().AddMinutes(5);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim(ClaimTypes.Expiration, tokenExpirationDate.ToString())
                }),
                Expires = tokenExpirationDate,
                NotBefore = DateTime.UtcNow.ToLocalTime(),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var userToken = new UserToken(
                user.UserName, authenticated: true, tokenHandler.WriteToken(securityToken), tokenExpirationDate);
            return Task.FromResult(userToken);
        }
    }
}
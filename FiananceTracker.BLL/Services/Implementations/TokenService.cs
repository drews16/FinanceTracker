using FiananceTracker.BLL.Services.Interfaces;
using FinanceTracker.Common.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FiananceTracker.BLL.Services.Implementations
{
    public sealed class TokenService(
        IOptions<JwtSettings> options) : ITokenService
    {
        public string CreateJwtToken(IEnumerable<Claim> claims)
        {
            int expire = options.Value.Expire;

            var jwt = new JwtSecurityToken(
                issuer: options.Value.Issuer,
                audience: options.Value.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(expire),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(options.Value.Key)
                        ), SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler()
                .WriteToken(jwt);
        }
    }
}
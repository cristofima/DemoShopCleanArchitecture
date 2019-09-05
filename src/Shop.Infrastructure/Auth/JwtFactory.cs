using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shop.Core.DTO;
using Shop.Core.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Shop.Infrastructure.Auth
{
    public class JwtFactory : IJwtFactory
    {
        private readonly JwtOptions _jwtOptions;

        public JwtFactory(IOptions<JwtOptions> jwtOptions)
        {
            this._jwtOptions = jwtOptions.Value;
        }

        public string GenerateEncodedToken(string userName, string email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._jwtOptions.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                 new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(this._jwtOptions.Issuer, this._jwtOptions.Issuer,
              claims,
              expires: DateTime.Now.AddMinutes(this._jwtOptions.ValidForMinutes),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
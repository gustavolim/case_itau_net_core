using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Case.Itau.Business.Services.V1.Login
{
    public class Login : ILogin
    {
        private const string SecretKey = "teste-itau-fundos-investimento-secure-long-secret-key";
        private const string Issuer = "itau-teste";
        private const string Audience = "itau-teste";

        public string GerarToken()
        {
            // Define o algoritmo de assinatura
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Define as reivindicações (claims)
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, "userId"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, "gustavo"),
            new Claim(ClaimTypes.Role, "teste")
        };

            // Cria o token
            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(24),
                signingCredentials: credentials);

            // Retorna o token como uma string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}


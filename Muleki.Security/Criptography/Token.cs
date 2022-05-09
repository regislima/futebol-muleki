using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Muleki.Common.Extensions;
using Muleki.Domain.Entities;

namespace Muleki.Security.Criptography
{
    public class Token
    {
        public static string GenerateJWTToken(IConfiguration configuration, Player player)
        {
            int tokenExpiredTimeLapse = int.Parse(configuration["Jwt:TokenExpireTimeLapse"]);
            byte[] key = Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]);
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, player.Name),
                    new Claim(ClaimTypes.Role, player.Role.GetEnumDescription())
                }),

                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Audience"],
                Expires = DateTime.UtcNow.AddHours(tokenExpiredTimeLapse),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            SecurityToken token = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);

            return jwtSecurityTokenHandler.WriteToken(token);
        }

        public static string GenerateSecretKey()
        {
            byte[] secret = new byte[32];

            RandomNumberGenerator.Create().GetBytes(secret);
            
            return Convert.ToBase64String(secret);
        }
    }
}
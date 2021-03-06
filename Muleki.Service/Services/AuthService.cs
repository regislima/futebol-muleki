using AutoMapper;
using Microsoft.Extensions.Configuration;
using Muleki.Domain.Entities;
using Muleki.Infra.Interfaces;
using Muleki.Security.Criptography;
using Muleki.Service.Dto;

namespace Muleki.Service.Services
{
    public class AuthService : BaseService<IPlayerRepository>
    {
        private readonly IConfiguration _configuration;

        public AuthService(IMapper mapper, IPlayerRepository serviceRepository, IConfiguration configuration) : base(mapper, serviceRepository)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(PlayerDto playerDto)
        {
            Player player = _mapper.Map<Player>(playerDto);

            return Token.GenerateJWTToken(_configuration, player);
        }

        public bool VerifyPasswordHash(AuthDto authDto)
        {
            Player player = _entityRepository.FindByEmail(authDto.Email).Result;
            byte[] passwordHash = Convert.FromBase64String(player.PasswordHash);
            byte[] passwordSalt = Convert.FromBase64String(player.PasswordSalt);
            
            return Crypt.VerifyPasswordHash(authDto.Password, passwordHash, passwordSalt);
        }
    }
}
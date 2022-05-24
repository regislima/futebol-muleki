using AutoMapper;
using Muleki.Common.Extensions;
using Muleki.Domain.Entities;
using Muleki.Exceptions;
using Muleki.Infra.Interfaces;
using Muleki.Security.Criptography;
using Muleki.Service.Dto;
using Muleki.Service.Interfaces;

namespace Muleki.Service.Services
{
    public class PlayerService : BaseService<IPlayerRepository>, IPlayerService
    {
        public PlayerService(IMapper mapper, IPlayerRepository serviceRepository) : base(mapper, serviceRepository) { }

        public async Task<PlayerDto> Create(PlayerDto objDto)
        {
            Player player = await _entityRepository.FindByEmail(objDto.Email);

            if (!player.IsNull())
                throw new DomainException("Já existe cadastro com email informado");
            
            Crypt.CreatePasswordHash(objDto.Password, out byte[] PasswordHash, out byte[] PasswordSalt);
            
            player = _mapper.Map<Player>(objDto);
            player.PasswordHash = Convert.ToBase64String(PasswordHash);
            player.PasswordSalt = Convert.ToBase64String(PasswordSalt);
            player.Created_At = DateTime.Now;
            player.Validate();
            
            Player playerCreated = await _entityRepository.Create(player);

            return _mapper.Map<PlayerDto>(playerCreated);
        }

        public async Task<List<PlayerDto>> FindAll()
        {
            List<Player> players = await _entityRepository.FindAll();
            
            return _mapper.Map<List<PlayerDto>>(players);
        }

        public async Task<PlayerDto> FindByEmail(string email)
        {
            Player player = await _entityRepository.FindByEmail(email);

            return _mapper.Map<PlayerDto>(player);
        }

        public async Task<PlayerDto> FindById(long id)
        {
            Player player = await _entityRepository.FindById(id);

            return _mapper.Map<PlayerDto>(player);
        }

        public async Task<List<PlayerDto>> FindByName(string name)
        {
            List<Player> players = await _entityRepository.FindByName(name);
            
            return _mapper.Map<List<PlayerDto>>(players);
        }

        public async Task<List<PlayerDto>> FindByNick(string nick)
        {
            List<Player> players = await _entityRepository.FindByNick(nick);
            
            return _mapper.Map<List<PlayerDto>>(players);
        }

        public async Task<List<FootballDto>> FindFootballs(long playerId)
        {   
            List<Football> footballs = await _entityRepository.FindFootballs(playerId);
            
            return _mapper.Map<List<FootballDto>>(footballs);
        }

        public async Task<List<ScoreDto>> FindScores(long playerId)
        {
            List<Score> scores = await _entityRepository.FindScores(playerId);
            
            return _mapper.Map<List<ScoreDto>>(scores);
        }

        public async Task<PlayerDto> Remove(long id)
        {
            Player player = await _entityRepository.FindById(id);

            if (player.IsNull())
                throw new DomainException("Jogador não encontrado");
            
            await _entityRepository.Remove(player);

            return _mapper.Map<PlayerDto>(player);
        }

        public async Task<PlayerDto> Update(PlayerDto objDto)
        {
            Player existEmail;
            Player player = await _entityRepository.FindById(objDto.Id);

            if (player.IsNull())
                throw new DomainException("Jogador não encontrado");
            
            if (!player.Email.Equals(objDto.Email))
            {
                existEmail = await _entityRepository.FindByEmail(objDto.Email);

                if (!existEmail.IsNull())
                    throw new DomainException("Já existe cadastro com email informado");
            }
            
            player = _mapper.Map(objDto, player);
            player.Updated_At = DateTime.Now;
            player.Validate();

            Player playerUpdated = await _entityRepository.Update(player);

            return _mapper.Map<PlayerDto>(player);
        }
    }
}
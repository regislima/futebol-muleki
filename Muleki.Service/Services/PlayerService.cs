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
    public class PlayerService : IPlayerService
    {
        private readonly IMapper _mapper;
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IMapper mapper, IPlayerRepository playerRepository)
        {
            _mapper = mapper;
            _playerRepository = playerRepository;
        }

        public async Task<PlayerDto> Create(PlayerDto objDto)
        {
            Player player = await _playerRepository.FindByEmail(objDto.Email);

            if (!player.IsNull())
                throw new DomainException("Já existe cadastro com email informado");
            
            Crypt.CreatePasswordHash(objDto.Password, out byte[] PasswordHash, out byte[] PasswordSalt);
            
            player = _mapper.Map<Player>(objDto);
            player.PasswordHash = Convert.ToBase64String(PasswordHash);
            player.PasswordSalt = Convert.ToBase64String(PasswordSalt);
            player.Created_At = DateTime.Now;
            player.Validate();
            
            Player playerCreated = await _playerRepository.Create(player);

            return _mapper.Map<PlayerDto>(playerCreated);
        }

        public async Task<List<PlayerDto>> FindAll()
        {
            List<Player> players = await _playerRepository.FindAll();
            
            return _mapper.Map<List<PlayerDto>>(players);
        }

        public async Task<PlayerDto> FindByEmail(string email)
        {
            Player player = await _playerRepository.FindByEmail(email);

            return _mapper.Map<PlayerDto>(player);
        }

        public async Task<PlayerDto> FindById(long id)
        {
            Player player = await _playerRepository.FindById(id);

            return _mapper.Map<PlayerDto>(player);
        }

        public async Task<List<PlayerDto>> FindByName(string name)
        {
            List<Player> players = await _playerRepository.FindByName(name);
            
            return _mapper.Map<List<PlayerDto>>(players);
        }

        public async Task<List<PlayerDto>> FindByNick(string nick)
        {
            List<Player> players = await _playerRepository.FindByNick(nick);
            
            return _mapper.Map<List<PlayerDto>>(players);
        }

        public async Task<List<FootballDto>> FindFootballs(long playerId)
        {   
            List<Football> footballs = await _playerRepository.FindFootballs(playerId);
            
            return _mapper.Map<List<FootballDto>>(footballs);
        }

        public async Task<List<ScoreDto>> FindScores(long playerId)
        {
            List<Score> scores = await _playerRepository.FindScores(playerId);
            
            return _mapper.Map<List<ScoreDto>>(scores);
        }

        public async Task<PlayerDto> Remove(long id)
        {
            Player player = await _playerRepository.FindById(id);

            if (player.IsNull())
                throw new DomainException("Jogador não encontrado");
            
            await _playerRepository.Remove(player);

            return _mapper.Map<PlayerDto>(player);
        }

        public async Task<PlayerDto> Update(PlayerDto objDto)
        {
            Player existEmail;
            Player player = await _playerRepository.FindById(objDto.Id);

            if (player.IsNull())
                throw new DomainException("Jogador não encontrado");
            
            if (!player.Email.Equals(objDto.Email))
            {
                existEmail = await _playerRepository.FindByEmail(objDto.Email);

                if (!existEmail.IsNull())
                    throw new DomainException("Já existe cadastro com email informado");
            }
            
            player = _mapper.Map(objDto, player);
            player.Updated_At = DateTime.Now;
            player.Validate();

            Player playerUpdated = await _playerRepository.Update(player);

            return _mapper.Map<PlayerDto>(player);
        }
    }
}
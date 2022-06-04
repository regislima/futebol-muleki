using AutoMapper;
using Muleki.Common.Extensions;
using Muleki.Domain.Entities;
using Muleki.Exceptions;
using Muleki.Infra.Interfaces;
using Muleki.Service.Dto;
using Muleki.Service.Interfaces;

namespace Muleki.Service.Services
{
    public class PlayerfootballService : BaseService<IPlayerFootballRepository>, IPlayerFootballService
    {
        public PlayerfootballService(IMapper mapper, IPlayerFootballRepository entityRepository) : base(mapper, entityRepository)
        { }

        public async Task<PlayerFootballDto> Create(PlayerFootballDto objDto)
        {
            PlayerFootball playerFootball = _mapper.Map<PlayerFootball>(objDto);
            playerFootball.Created_At = DateTime.Now;
            playerFootball.Validate();
            playerFootball = await _entityRepository.Create(playerFootball);

            return _mapper.Map<PlayerFootballDto>(playerFootball);
        }

        public async Task<List<PlayerFootballDto>> FindAll()
        {
            List<PlayerFootball> playerFootballs = await _entityRepository.FindAll();
            
            return _mapper.Map<List<PlayerFootballDto>>(playerFootballs);
        }

        public async Task<PlayerFootballDto> FindById(long id)
        {
            PlayerFootball playerFootball = await _entityRepository.FindById(id);
            
            return _mapper.Map<PlayerFootballDto>(playerFootball);
        }

        public async Task<PlayerFootballDto> Remove(long id)
        {
            PlayerFootball playerFootball = await _entityRepository.FindById(id);

            if (playerFootball.IsNull())
                throw new DomainException("Partida não encontrada");
            
            await _entityRepository.Remove(playerFootball);

            return _mapper.Map<PlayerFootballDto>(playerFootball);
        }

        public async Task<PlayerFootballDto> Update(PlayerFootballDto objDto)
        {
            PlayerFootball playerFootball = await _entityRepository.FindById(objDto.Id);

            if (playerFootball.IsNull())
                throw new DomainException("PArtida não encontrada");
            
            playerFootball = _mapper.Map(objDto, playerFootball);
            playerFootball.Updated_At = DateTime.Now;
            playerFootball.Validate();

            playerFootball = await _entityRepository.Update(playerFootball);

            return _mapper.Map<PlayerFootballDto>(playerFootball);
        }
    }
}
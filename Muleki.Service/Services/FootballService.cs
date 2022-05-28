using AutoMapper;
using Muleki.Common.Extensions;
using Muleki.Domain.Entities;
using Muleki.Exceptions;
using Muleki.Infra.Interfaces;
using Muleki.Service.Dto;
using Muleki.Service.Interfaces;

namespace Muleki.Service.Services
{
    public class FootballService : BaseService<IFootballRepository>, IFootballService
    {
        public FootballService(IMapper mapper, IFootballRepository entityRepository) : base(mapper, entityRepository) { }

        public async Task<FootballDto> Create(FootballDto objDto)
        {           
            Football football = _mapper.Map<Football>(objDto);
            football.Created_At = DateTime.Now;
            football.Validate();
            
            football = await _entityRepository.Create(football);

            return _mapper.Map<FootballDto>(football);
        }

        public async Task<List<FootballDto>> FindAll()
        {
            List<Football> footballs = await _entityRepository.FindAll();
            
            return _mapper.Map<List<FootballDto>>(footballs);
        }

        public async Task<FootballDto> FindByDate(DateTime date)
        {
            Football football = await _entityRepository.FindByDate(date);
            
            return _mapper.Map<FootballDto>(football);
        }

        public async Task<FootballDto> FindById(long id)
        {
            Football football = await _entityRepository.FindById(id);
            
            return _mapper.Map<FootballDto>(football);
        }

        public async Task<FootballDto> Remove(long id)
        {
            Football football = await _entityRepository.FindById(id);

            if (football.IsNull())
                throw new DomainException("Futebol não encontrado");
            
            await _entityRepository.Remove(football);

            return _mapper.Map<FootballDto>(football);
        }

        public async Task<FootballDto> Update(FootballDto objDto)
        {
            Football football = await _entityRepository.FindById(objDto.Id);

            if (football.IsNull())
                throw new DomainException("Futebol não encontrado");
            
            football = _mapper.Map(objDto, football);
            football.Updated_At = DateTime.Now;
            football.Validate();

            football = await _entityRepository.Update(football);

            return _mapper.Map<FootballDto>(football);
        }
    }
}
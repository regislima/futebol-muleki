using AutoMapper;
using Muleki.Common.Extensions;
using Muleki.Domain.Entities;
using Muleki.Exceptions;
using Muleki.Infra.Interfaces;
using Muleki.Service.Dto;
using Muleki.Service.Interfaces;

namespace Muleki.Service.Services
{
    public class ScoreService : BaseService<IScoreRepository>, IScoreService
    {
        public ScoreService(IMapper mapper, IScoreRepository serviceRepository) : base(mapper, serviceRepository) { }

        public async Task<ScoreDto> Create(ScoreDto objDto)
        {            
            Score score = _mapper.Map<Score>(objDto);
            score.Created_At = DateTime.Now;
            score.Validate();
            score = await _entityRepository.Create(score);
            
            return _mapper.Map<ScoreDto>(score);
        }

        public async Task<List<ScoreDto>> FindAll()
        {
            List<Score> scores = await _entityRepository.FindAll();

            return _mapper.Map<List<ScoreDto>>(scores);
        }

        public async Task<ScoreDto> FindById(long id)
        {
            Score score = await _entityRepository.FindById(id);

            return _mapper.Map<ScoreDto>(score);
        }

        public async Task<ScoreDto> Remove(long id)
        {
            Score score = await _entityRepository.FindById(id);

            if (score.IsNull())
                throw new DomainException("Score não encontrado");

            await _entityRepository.Remove(score);

            return _mapper.Map<ScoreDto>(score);
        }

        public async Task<ScoreDto> Update(ScoreDto objDto)
        {
            Score score = await _entityRepository.FindById(objDto.Id);

            if (score.IsNull())
                throw new DomainException("Score não encontrado");
            
            _mapper.Map(objDto, score);
            score.Updated_At = DateTime.Now;
            score.Validate();
            score = await _entityRepository.Update(score);
            
            return _mapper.Map<ScoreDto>(score);
        }
    }
}
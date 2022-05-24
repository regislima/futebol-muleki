using AutoMapper;
using Muleki.Common.Extensions;
using Muleki.Domain.Entities;
using Muleki.Exceptions;
using Muleki.Infra.Interfaces;
using Muleki.Service.Dto;
using Muleki.Service.Interfaces;

namespace Muleki.Service.Services
{
    public class SafeboxService : BaseService<ISafeboxRepository>, ISafeboxService
    {
        public SafeboxService(IMapper mapper, ISafeboxRepository serviceRepository) : base(mapper, serviceRepository) { }

        public async Task<SafeboxDto> Create(SafeboxDto objDto)
        {            
            Safebox safebox = _mapper.Map<Safebox>(objDto);
            safebox.Validate();
            safebox = await _entityRepository.Create(safebox);
            
            return _mapper.Map<SafeboxDto>(safebox);
        }

        public async Task<List<SafeboxDto>> FindAll()
        {
            List<Safebox> safeboxes = await _entityRepository.FindAll();

            return _mapper.Map<List<SafeboxDto>>(safeboxes);
        }

        public async Task<SafeboxDto> FindByFootballId(long footballId)
        {
            Safebox safebox = await _entityRepository.FindByFootballId(footballId);

            return _mapper.Map<SafeboxDto>(safebox);
        }

        public async Task<SafeboxDto> FindById(long id)
        {
            Safebox safebox = await _entityRepository.FindById(id);

            return _mapper.Map<SafeboxDto>(safebox);
        }

        public async Task<SafeboxDto> Remove(long id)
        {
            Safebox safebox = await _entityRepository.FindById(id);

            if (safebox.IsNull())
                throw new DomainException("Cofre não encontrado");

            await _entityRepository.Remove(safebox);

            return _mapper.Map<SafeboxDto>(safebox);
        }

        public async Task<SafeboxDto> Update(SafeboxDto objDto)
        {
            Safebox safebox = await _entityRepository.FindById(objDto.Id);

            if (safebox.IsNull())
                throw new DomainException("Cofre não encontrado");
            
            _mapper.Map(safebox, objDto);
            safebox.Validate();
            safebox = await _entityRepository.Update(safebox);
            
            return _mapper.Map<SafeboxDto>(safebox);
        }
    }
}
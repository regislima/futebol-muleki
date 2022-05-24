using AutoMapper;

namespace Muleki.Service.Services
{
    public abstract class BaseService<T>
    {
        protected readonly IMapper _mapper;
        protected readonly T _entityRepository;

        protected BaseService(IMapper mapper, T entityRepository)
        {
            _mapper = mapper;
            _entityRepository = entityRepository;
        }
    }
}
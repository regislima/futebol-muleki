using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Muleki.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class SafeboxController : ControllerBase
    {
        private readonly IMapper _mapper;
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Muleki.Api.InputModels.Player;
using Muleki.Common.Communication;
using Muleki.Common.Extensions;
using Muleki.Exceptions;
using Muleki.Service.DTO;
using Muleki.Service.Interfaces;

namespace Muleki.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerSevice;
        private readonly IMapper _mapper;

        public PlayerController(IPlayerService playerService, IMapper mapper)
        {
            _playerSevice = playerService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("v1/player/create")]
        public async Task<IActionResult> Create([FromBody] PlayerCreateInput playerCreateInput)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(DataResponse.Error(playerCreateInput, ModelState.GetErrorMessage()));
                
                PlayerDto playerDto = _mapper.Map<PlayerDto>(playerCreateInput);
                PlayerDto userCreated = await _playerSevice.Create(playerDto);
                
                return Ok(DataResponse.Success(userCreated));
            }
            catch (DomainException ex)
            {
                return BadRequest(DataResponse.Error(ex.Errors, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, DataResponse.Error(null, ex.Message));
            }
        }
    }
}
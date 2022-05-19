using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Muleki.Api.InputModels.Player;
using Muleki.Common.Communication;
using Muleki.Common.Extensions;
using Muleki.Exceptions;
using Muleki.Service.Dto;
using Muleki.Service.Interfaces;

namespace Muleki.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        public PlayerController(IPlayerService playerService, IMapper mapper)
        {
            _playerService = playerService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("v1/player/create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] PlayerCreateInput playerCreateInput)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(DataResponse.Error(playerCreateInput, ModelState.GetErrorMessage()));
                
                PlayerDto playerDto = _mapper.Map<PlayerDto>(playerCreateInput);
                PlayerDto playerCreated = await _playerService.Create(playerDto);
                
                return Ok(DataResponse.Success(playerCreated));
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

        [HttpPut]
        [Route("v1/player/update")]
        [Authorize(Roles = "Administrador, Jogador")]
        public async Task<IActionResult> Update([FromBody] PlayerUpdateInput playerUpdateInput)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(DataResponse.Error(playerUpdateInput, ModelState.GetErrorMessage()));
                
                PlayerDto playerDto = _mapper.Map<PlayerDto>(playerUpdateInput);
                PlayerDto playerUpdated = await _playerService.Update(playerDto);
                
                return Ok(DataResponse.Success(playerUpdated));
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

        [HttpDelete]
        [Route("v1/player/remove/{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                PlayerDto playerRemoved = await _playerService.Remove(id);
                
                return Ok(DataResponse.Success(playerRemoved));
            }
            catch (DomainException ex)
            {
                return BadRequest(DataResponse.Error(ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, DataResponse.Error(null, ex.Message));
            }
        }

        [HttpGet]
        [Route("v1/player/find/id")]
        [Authorize(Roles = "Administrador, Jogador")]
        public async Task<IActionResult> Find([FromQuery] long id)
        {
            try
            {
                PlayerDto playerDto = await _playerService.FindById(id);

                return (playerDto.IsNull() ? 
                    Ok(DataResponse.Success(null, "Nenhum registro encontrado")) : 
                    Ok(DataResponse.Success(playerDto)));
            }
            catch (DomainException ex)
            {
                return BadRequest(DataResponse.Error(ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, DataResponse.Error(null, ex.Message));
            }
        }

        [HttpGet]
        [Route("v1/player/find/all")]
        [Authorize(Roles = "Administrador, Jogador")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                List<PlayerDto> playerDtos = await _playerService.FindAll();

                return ((playerDtos.IsNull() || playerDtos.Count == 0) ? 
                    Ok(DataResponse.Success(null, "Nenhum registro encontrado")) : 
                    Ok(DataResponse.Success(playerDtos)));
            }
            catch (DomainException ex)
            {
                return BadRequest(DataResponse.Error(ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, DataResponse.Error(null, ex.Message));
            }
        }

        [HttpGet]
        [Route("v1/player/find/email")]
        [Authorize(Roles = "Administrador, Jogador")]
        public async Task<IActionResult> FindByEmail([FromQuery] string email)
        {
            try
            {
                PlayerDto playerDto = await _playerService.FindByEmail(email);

                return (playerDto.IsNull() ? Ok(DataResponse.Success(null, "Nenhum registro encontrado")) : Ok(DataResponse.Success(playerDto)));
            }
            catch (DomainException ex)
            {
                return BadRequest(DataResponse.Error(ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, DataResponse.Error(null, ex.Message));
            }
        }

        [HttpGet]
        [Route("v1/player/find/name")]
        [Authorize(Roles = "Administrador, Jogador")]
        public async Task<IActionResult> FindByName([FromQuery] string name)
        {
            try
            {
                List<PlayerDto> playerList = await _playerService.FindByName(name);

                return (playerList.Count == 0 ? Ok(DataResponse.Success(null, "Nenhum registro encontrado")) : Ok(DataResponse.Success(playerList)));
            }
            catch (DomainException ex)
            {
                return BadRequest(DataResponse.Error(ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, DataResponse.Error(null, ex.Message));
            }
        }

        [HttpGet]
        [Route("v1/player/find/nick")]
        [Authorize(Roles = "Administrador, Jogador")]
        public async Task<IActionResult> FindByNick([FromQuery] string nick)
        {
            try
            {
                List<PlayerDto> playerList = await _playerService.FindByNick(nick);

                return (playerList.Count == 0 ? Ok(DataResponse.Success(null, "Nenhum registro encontrado")) : Ok(DataResponse.Success(playerList)));
            }
            catch (DomainException ex)
            {
                return BadRequest(DataResponse.Error(ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, DataResponse.Error(null, ex.Message));
            }
        }
    }
}
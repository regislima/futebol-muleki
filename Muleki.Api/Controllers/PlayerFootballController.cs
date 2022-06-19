using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Muleki.Api.InputModels.PlayerFootball;
using Muleki.Common.Communication;
using Muleki.Common.Extensions;
using Muleki.Exceptions;
using Muleki.Service.Dto;
using Muleki.Service.Interfaces;

namespace Muleki.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class PlayerFootballController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPlayerFootballService _playerFootballService;

        public PlayerFootballController(IMapper mapper, IPlayerFootballService playerFootballService)
        {
            _mapper = mapper;
            _playerFootballService = playerFootballService;
        }

        [HttpPost]
        [Route("v1/playerfootball/create")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create(PlayerFootballCreateInput playerFootballCreateInput)
        {
            try
            {
                PlayerFootballDto playerFootballDto = _mapper.Map<PlayerFootballDto>(playerFootballCreateInput);
                playerFootballDto = await _playerFootballService.Create(playerFootballDto);
                
                return Ok(DataResponse.Success(playerFootballDto));
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
        [Route("v1/playerfootball/remove/{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                PlayerFootballDto playerFootballDto = await _playerFootballService.Remove(id);
                
                return Ok(DataResponse.Success(playerFootballDto));
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
        [Route("v1/playerfootball/find/id")]
        [Authorize(Roles = "Administrador, Jogador")]
        public async Task<IActionResult> FindById([FromQuery] long id)
        {
            try
            {
                PlayerFootballDto playerFootballDto = await _playerFootballService.FindById(id);

                return (playerFootballDto.IsNull() ? 
                    Ok(DataResponse.Success(null, "Nenhum registro encontrado")) : 
                    Ok(DataResponse.Success(playerFootballDto)));
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
        [Route("v1/playerfootball/find/all")]
        [Authorize(Roles = "Administrador, Jogador")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                List<PlayerFootballDto> playerFootballDtos = await _playerFootballService.FindAll();

                return ((playerFootballDtos.IsNull() || playerFootballDtos.Count == 0) ? 
                    Ok(DataResponse.Success(null, "Nenhum registro encontrado")) : 
                    Ok(DataResponse.Success(playerFootballDtos)));
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

        [HttpDelete]
        [Route("v1/playerfootball/remove/player")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> RemovePlayer([FromQuery] long playerId)
        {
            try
            {
                PlayerFootballDto playerFootballDto = await _playerFootballService.RemovePlayer(playerId);

                return Ok(DataResponse.Success(playerFootballDto));
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
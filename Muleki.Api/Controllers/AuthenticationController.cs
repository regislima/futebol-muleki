using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Muleki.Api.InputModels.Auth;
using Muleki.Common.Communication;
using Muleki.Common.Extensions;
using Muleki.Exceptions;
using Muleki.Service.Dto;
using Muleki.Service.Interfaces;
using Muleki.Service.Services;

namespace Muleki.Api.Controllers
{
    [ApiController]
    [Route("api")]
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly AuthService _authService;
        private readonly IMapper _mapper;

        public AuthenticationController(IPlayerService playerService, AuthService authService, IMapper mapper)
        {
            _playerService = playerService;
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("v1/auth/login")]
        public async Task<IActionResult> Authenticate([FromBody] AuthInput authInput)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(DataResponse.Error(authInput, ModelState.GetErrorMessage()));

                PlayerDto playerDto = await _playerService.FindByEmail(authInput.Email);
                
                if (playerDto.IsNull())
                    return BadRequest(DataResponse.Error(null, "Email ou senha inválido"));
                
                AuthDto authDto = _mapper.Map<AuthDto>(authInput);
                
                if (!_authService.VerifyPasswordHash(authDto))
                    return BadRequest(DataResponse.AuthorizationError(null, "Email ou senha incorretos."));
                
                authDto.Player = playerDto;
                authDto.Token = _authService.GenerateJwtToken(playerDto);

                return Ok(DataResponse.Success(authDto));
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
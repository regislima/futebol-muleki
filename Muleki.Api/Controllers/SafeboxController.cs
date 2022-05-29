using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Muleki.Api.InputModels.Safebox;
using Muleki.Common.Communication;
using Muleki.Common.Extensions;
using Muleki.Exceptions;
using Muleki.Service.Dto;
using Muleki.Service.Interfaces;

namespace Muleki.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class SafeboxController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISafeboxService _safeboxService;

        public SafeboxController(IMapper mapper, ISafeboxService safeboxService)
        {
            _mapper = mapper;
            _safeboxService = safeboxService;
        }

        [HttpPost]
        [Route("v1/safebox/create")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create([FromBody] SafeboxCreateInput safeboxCreateInput)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(DataResponse.Error(safeboxCreateInput, ModelState.GetErrorMessage()));
                
                SafeboxDto safeboxDto = _mapper.Map<SafeboxDto>(safeboxCreateInput);
                safeboxDto = await _safeboxService.Create(safeboxDto);
                
                return Ok(DataResponse.Success(safeboxDto));
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
        [Route("v1/safebox/update")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Update([FromBody] SafeboxUpdateInput safeboxUpdateInput)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(DataResponse.Error(safeboxUpdateInput, ModelState.GetErrorMessage()));
                
                SafeboxDto safeboxDto = _mapper.Map<SafeboxDto>(safeboxUpdateInput);
                safeboxDto = await _safeboxService.Update(safeboxDto);
                
                return Ok(DataResponse.Success(safeboxDto));
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
        [Route("v1/safebox/remove/{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                SafeboxDto safeboxDto = await _safeboxService.Remove(id);
                
                return Ok(DataResponse.Success(safeboxDto));
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
        [Route("v1/safebox/find/id")]
        [Authorize(Roles = "Administrador, Jogador")]
        public async Task<IActionResult> FindById([FromQuery] long id)
        {
            try
            {
                SafeboxDto safeboxDto = await _safeboxService.FindById(id);

                return (safeboxDto.IsNull() ? 
                    Ok(DataResponse.Success(null, "Nenhum registro encontrado")) : 
                    Ok(DataResponse.Success(safeboxDto)));
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
        [Route("v1/safebox/find/all")]
        [Authorize(Roles = "Administrador, Jogador")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                List<SafeboxDto> safeboxDtos = await _safeboxService.FindAll();

                return ((safeboxDtos.IsNull() || safeboxDtos.Count == 0) ? 
                    Ok(DataResponse.Success(null, "Nenhum registro encontrado")) : 
                    Ok(DataResponse.Success(safeboxDtos)));
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
        [Route("v1/safebox/find/football")]
        [Authorize(Roles = "Administrador, Jogador")]
        public async Task<IActionResult> FindByFootballId([FromQuery] long footballId)
        {
            try
            {
                SafeboxDto safeboxDto = await _safeboxService.FindByFootballId(footballId);

                return (safeboxDto.IsNull() ? 
                    Ok(DataResponse.Success(null, "Nenhum registro encontrado")) : 
                    Ok(DataResponse.Success(safeboxDto)));
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
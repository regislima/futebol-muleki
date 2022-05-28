using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Muleki.Api.InputModels.Football;
using Muleki.Common.Communication;
using Muleki.Common.Extensions;
using Muleki.Exceptions;
using Muleki.Service.Dto;
using Muleki.Service.Interfaces;

namespace Muleki.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class FootballController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFootballService _footballService;

        public FootballController(IMapper mapper, IFootballService footballService)
        {
            _mapper = mapper;
            _footballService = footballService;
        }

        [HttpPost]
        [Route("v1/football/create")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create()
        {
            try
            {
                FootballDto footballDto = await _footballService.Create(new FootballDto());
                
                return Ok(DataResponse.Success(footballDto));
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
        [Route("v1/football/update")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Update([FromBody] FootballUpdateInput footballUpdateInput)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(DataResponse.Error(footballUpdateInput, ModelState.GetErrorMessage()));
                
                FootballDto footballDto = _mapper.Map<FootballDto>(footballUpdateInput);
                footballDto = await _footballService.Update(footballDto);
                
                return Ok(DataResponse.Success(footballDto));
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
        [Route("v1/football/remove/{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                FootballDto footballDto = await _footballService.Remove(id);
                
                return Ok(DataResponse.Success(footballDto));
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
        [Route("v1/football/find/id")]
        [Authorize(Roles = "Administrador, Jogador")]
        public async Task<IActionResult> Find([FromQuery] long id)
        {
            try
            {
                FootballDto footballDto = await _footballService.FindById(id);

                return (footballDto.IsNull() ? 
                    Ok(DataResponse.Success(null, "Nenhum registro encontrado")) : 
                    Ok(DataResponse.Success(footballDto)));
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
        [Route("v1/football/find/all")]
        [Authorize(Roles = "Administrador, Jogador")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                List<FootballDto> footballDtos = await _footballService.FindAll();

                return ((footballDtos.IsNull() || footballDtos.Count == 0) ? 
                    Ok(DataResponse.Success(null, "Nenhum registro encontrado")) : 
                    Ok(DataResponse.Success(footballDtos)));
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
        [Route("v1/football/find/date")]
        [Authorize(Roles = "Administrador, Jogador")]
        public async Task<IActionResult> FindByDate([FromQuery] DateTime date)
        {
            try
            {
                FootballDto footballDto = await _footballService.FindByDate(date);

                return (footballDto.IsNull() ? 
                    Ok(DataResponse.Success(null, "Nenhum registro encontrado")) : 
                    Ok(DataResponse.Success(footballDto)));
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
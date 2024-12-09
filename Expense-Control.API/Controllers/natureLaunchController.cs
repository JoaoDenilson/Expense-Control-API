using Expense_Control.API.Contract.NatureLaunch;
using Expense_Control.API.Domain.Models;
using Expense_Control.API.Domain.Services;
using Expense_Control.API.Domain.Services.Interfaces;
using Expense_Control.API.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace Expense_Control.API.Controllers
{
    [ApiController]
    [Route("natureslaunch")]
    public class natureLaunchController : BaseController
    {
        private readonly ILogger<natureLaunchController> _logger;
        private readonly IService<NatureLaunchRequestDTO, NatureLaunchResponseDTO, long> _natureLaunchService;

        private long _userId;
        public natureLaunchController(
            ILogger<natureLaunchController> logger, 
            IService<NatureLaunchRequestDTO, NatureLaunchResponseDTO, long> natureLaunchService)
        {
            _logger = logger;
            _natureLaunchService = natureLaunchService;        
        }

        [HttpPost]
        public async Task<ActionResult> Add(NatureLaunchRequestDTO contract) 
        {
            try
            {
                _userId = GetIdUserLogged();
                var result = await _natureLaunchService.Add(contract, _userId);
                return Created();
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ReturnBadRequest(ex));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                _userId = GetIdUserLogged();
                var result = await _natureLaunchService.Get(_userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                _userId = GetIdUserLogged();
                var result = await _natureLaunchService.Get(id, _userId);
                return Ok(result);
            }
            catch (NotfoundException ex)
            {
                return NotFound(ReturnNotFound(ex));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<ActionResult> Update(long id, NatureLaunchRequestDTO contract)
        {
            try
            {
                _userId = GetIdUserLogged();
                var result = await _natureLaunchService.Update(id, contract, _userId);
                return Ok(result);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ReturnBadRequest(ex));
            }
            catch (NotfoundException ex)
            {
                return NotFound(ReturnNotFound(ex));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                _userId = GetIdUserLogged();
                await _natureLaunchService.Inactive(id, _userId);
                return NoContent();
            }
            catch (NotfoundException ex)
            {
                return NotFound(ReturnNotFound(ex));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}

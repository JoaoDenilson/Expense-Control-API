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
    [Route("title-to-receive")]
    public class titleToReceiveController : BaseController
    {
        private readonly ILogger<titleToReceiveController> _logger;
        private readonly IService<TitleToReceiveRequestDTO, TitleToReceiveResponseDTO, long> _titleToReceiveService;

        private long _userId;
        public titleToReceiveController(
            ILogger<titleToReceiveController> logger, 
            IService<TitleToReceiveRequestDTO, TitleToReceiveResponseDTO, long> titleToReceiveService)
        {
            _logger = logger;
            _titleToReceiveService = titleToReceiveService;        
        }

        [HttpPost]
        public async Task<ActionResult> Add(TitleToReceiveRequestDTO contract) 
        {
            try
            {
                _userId = GetIdUserLogged();
                var result = await _titleToReceiveService.Add(contract, _userId);
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
                var result = await _titleToReceiveService.Get(_userId);
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
                var result = await _titleToReceiveService.Get(id, _userId);
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
        public async Task<ActionResult> Update(long id, TitleToReceiveRequestDTO contract)
        {
            try
            {
                _userId = GetIdUserLogged();
                var result = await _titleToReceiveService.Update(id, contract, _userId);
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
                await _titleToReceiveService.Inactive(id, _userId);
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

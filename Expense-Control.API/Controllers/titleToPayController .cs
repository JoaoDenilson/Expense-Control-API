using Expense_Control.API.Contract;
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
    [Route("title-to-pay")]
    public class titleToPayController : BaseController
    {
        private readonly ILogger<titleToPayController> _logger;
        private readonly IService<TitleToPayRequestDTO, TitleToPayResponseDTO, long> _titleToPayService;

        private long _userId;
        public titleToPayController(
            ILogger<titleToPayController> logger, 
            IService<TitleToPayRequestDTO, TitleToPayResponseDTO, long> titleToPayService)
        {
            _logger = logger;
            _titleToPayService = titleToPayService;        
        }

        [HttpPost]
        public async Task<ActionResult> Add(TitleToPayRequestDTO contract) 
        {
            try
            {
                _userId = GetIdUserLogged();
                var result = await _titleToPayService.Add(contract, _userId);
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
                var result = await _titleToPayService.Get(_userId);
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
                var result = await _titleToPayService.Get(id, _userId);
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
        public async Task<ActionResult> Update(long id, TitleToPayRequestDTO contract)
        {
            try
            {
                _userId = GetIdUserLogged();
                var result = await _titleToPayService.Update(id, contract, _userId);
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
                await _titleToPayService.Inactive(id, _userId);
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

using Expense_Control.API.Contract.User;
using Expense_Control.API.Domain.Services.Interfaces;
using Expense_Control.API.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace Expense_Control.API.Controllers
{
    [ApiController]
    [Route("users")]
    public class userController : BaseController
    {
        private readonly ILogger<userController> _logger;
        private readonly IUserService _userService;
        public userController(ILogger<userController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Authentication(UserLoginRequestDTO contract)
        {
            try
            {
                var result = await _userService.Authenticate(contract);
                return Ok(result);
            }
            catch(AuthenticationException ae)
            {
                return Unauthorized(ReturnUnauthorized(ae));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add(UserRequestDTO contract) 
        {
            try
            {
                var result = await _userService.Add(contract, 0);
                return Created();
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

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var result = await _userService.Get(0);
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
                var result = await _userService.Get(id, 0);
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
        public async Task<ActionResult> Update(long id, UserRequestDTO contract)
        {
            try
            {
                var result = await _userService.Update(id, contract, 0);
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
                await _userService.Inactive(0, id);
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

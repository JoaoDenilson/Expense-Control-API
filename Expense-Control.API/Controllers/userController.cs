using Expense_Control.API.Contract.User;
using Expense_Control.API.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Expense_Control.API.Controllers
{
    [ApiController]
    [Route("users")]
    public class userController : ControllerBase
    {
        private readonly ILogger<userController> _logger;
        private readonly IUserService _userService;
        public userController(ILogger<userController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Add(UserRequestDTO contract) 
        {
            try
            {
                var result = await _userService.Add(contract, 0);
                return Created();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
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
        [AllowAnonymous]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                var result = await _userService.Get(id, 0);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> Update(long id, UserRequestDTO contract)
        {
            try
            {
                var result = await _userService.Update(id, contract, 0);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                await _userService.Inactive(0, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}

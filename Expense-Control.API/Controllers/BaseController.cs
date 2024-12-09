using Expense_Control.API.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Expense_Control.API.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected long GetIdUserLogged() 
        {
            var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            long.TryParse(id, out var userId);

            return userId;
        }    

        protected ModelErrorDTO ReturnBadRequest (Exception ex)
        {
            return new ModelErrorDTO
            {
                StatusCode = 400,
                Title = "Bad request",
                Message = ex.Message,
                DateTime = DateTime.Now,
            };
        }
        protected ModelErrorDTO ReturnNotFound (Exception ex)
        {
            return new ModelErrorDTO
            {
                StatusCode = 404,
                Title = "Not Found",
                Message = ex.Message,
                DateTime = DateTime.Now,
            };
        }
        protected ModelErrorDTO ReturnUnauthorized(Exception ex)
        {
            return new ModelErrorDTO
            {
                StatusCode = 401,
                Title = "Unauthorized",
                Message = ex.Message,
                DateTime = DateTime.Now,
            };
        }        
    }
}

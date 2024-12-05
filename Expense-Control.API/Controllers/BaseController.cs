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
    }
}

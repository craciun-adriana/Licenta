using LicentaAPI.Persistence.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LicentaAPI.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly UserManager<AppUser> _userManager;

        protected BaseController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        protected async Task<bool> UserIsAdminAsync()
        {
            var user = await _userManager.FindByIdAsync(_userManager.GetUserId(HttpContext.User));
            if (user == null)
            {
                return false;
            }
            return user.IsAdmin;
        }

        protected IActionResult CreateResponse<T>(int statusCode, T content)
        {
            if (statusCode >= 400)
            {
                var errorResponse = BadRequest(content);
                errorResponse.StatusCode = statusCode;
                return errorResponse;
            }

            var response = Ok(content);
            response.StatusCode = statusCode;
            return response;
        }
    }
}
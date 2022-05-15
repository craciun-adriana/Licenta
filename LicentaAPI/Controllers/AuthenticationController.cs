using LicentaAPI.Controllers.Models;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace LicentaAPI.Controllers
{
    [ApiController]
    [Route("licenta/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthenticationController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        [SwaggerResponse(204, "User is new registered.")]
        [SwaggerResponse(400, "Invalid input.")]
        public async Task<IActionResult> RegisterUserAsync(RegisterRequest request)
        {
            var user = new AppUser
            {
                UserName = request.UserName,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth.Value,
                Sex = request.Sex,
                IsAdmin = false,
                Rank = 0,
            };

            // The password is taken separately to encrypt.
            var registerResult = await _userManager.CreateAsync(user, request.Password);

            if (registerResult.Succeeded)
            {
                return NoContent();
            }

            // Means that the user entered wrong data.
            return BadRequest(registerResult.Errors);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [SwaggerResponse(204, "User is logged in.")]
        [SwaggerResponse(404, "No user found with given details.")]
        public async Task<IActionResult> LoginUserAsync(LoginRequest request)
        {
            var loginResult = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, request.RememberMe, false);

            if (loginResult.Succeeded)
            {
                return NoContent();
            }

            return NotFound(new { Error = "No account found with given details." });
        }

        [Authorize]
        [HttpPost("logout")]
        [SwaggerResponse(204, "User is logged out.")]
        [SwaggerResponse(404, "No user is logged id.")]
        public async Task<IActionResult> LogoutUserAsync()
        {
            await _signInManager.SignOutAsync();
            return NoContent();
        }

        [Authorize]
        [HttpGet("is-logged-in")]
        [SwaggerResponse(204, "User is logged out.")]
        [SwaggerResponse(404, "No user is logged id.")]
        public IActionResult IsLogged()
        {
            return Ok(_userManager.GetUserId(HttpContext.User));
        }
    }
}
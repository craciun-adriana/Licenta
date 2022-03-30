using LicentaAPI.Controllers.Models;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LicentaAPI.Controllers
{
    [ApiController]
    [Route("licenta/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMappingCoordinator _mapper;

        public AuthenticationController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMappingCoordinator mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("register")]
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
                IsAdmin = false
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
        public async Task<IActionResult> LogoutUserAsync()
        {
            await _signInManager.SignOutAsync();
            return NoContent();
        }
    }
}
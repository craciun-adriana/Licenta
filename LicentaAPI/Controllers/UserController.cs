using LicentaAPI.AppServices.Users;
using LicentaAPI.AppServices.Users.Models;
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
    [Route("licenta/user")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMappingCoordinator _mapper;

        public UserController(IUserService userService, IMappingCoordinator mapper, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager) : base(userManager)
        {
            _userService = userService;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("find/{userName}")]
        [SwaggerResponse(200, "Users with the given string in userName.")]
        public IActionResult FindUsersByUsername(string userName)
        {
            var loggedInUserId = _userManager.GetUserId(HttpContext.User);
            return Ok(_userService.FindUsersByUsername(userName, loggedInUserId));
        }

        [Authorize]
        [HttpGet("get/{idUser}")]
        [SwaggerResponse(200, "User with the given id.")]
        [SwaggerResponse(404, "User was not found.")]
        public IActionResult GetUserById(string idUser)
        {
            var user = _userService.GetUserById(idUser);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [Authorize]
        [HttpGet("get-all-users/{isAdmin}")]
        [SwaggerResponse(200, "User with the given id.")]
        public async Task<IActionResult> GetAllUsers(bool isAdmin)
        {
            if (!(await UserIsAdminAsync()))
            {
                return Unauthorized();
            }

            //if (isAdmin == "admin")
            //{
            //    return Ok(_userService.GetAllUsers(true));
            //}

            return Ok(_userService.GetAllUsers(isAdmin));
        }

        [Authorize]
        [HttpGet("find-friends/{userName}")]
        [SwaggerResponse(200, "Friends with the given string in userName.")]
        public IActionResult FindFriendsByUsername(string userName)
        {
            var loggedInUserId = _userManager.GetUserId(HttpContext.User);
            return Ok(_userService.FindFriendsByUsername(userName, loggedInUserId));
        }

        [Authorize]
        [HttpPost("update")]
        public IActionResult Update(UpdateUserRequest request)
        {
            var loggedUserId = _userManager.GetUserId(HttpContext.User);
            var userUpdate = _mapper.Map<UpdateUserRequest, UserUpdate>(request);
            userUpdate.ID = loggedUserId;

            return Ok(_userService.Update(userUpdate));
        }

        [Authorize]
        [HttpDelete("delete")]
        [SwaggerResponse(200, "User was deleted.")]
        public async Task<IActionResult> DeleteUser()
        {
            var user = _userManager.GetUserId(HttpContext.User);
            await _signInManager.SignOutAsync();
            _userService.DeleteUser(user);
            return Ok();
        }

        [Authorize]
        [HttpPost("update-admin-status")]
        public async Task<IActionResult> UpdateAdminStatus(UpdateAdminStatusRequest request)
        {
            if (!await UserIsAdminAsync())
            {
                return Unauthorized();
            }
            var userId = _userManager.GetUserId(HttpContext.User);
            if (request.ID == userId)
            {
                return BadRequest();
            }

            if (_userService.UpdateAdminStatus(request.ID, request.AdminStatus))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
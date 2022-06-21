using LicentaAPI.AppServices.Users;
using LicentaAPI.AppServices.Users.Models;
using LicentaAPI.Controllers.Models;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LicentaAPI.Controllers
{
    [ApiController]
    [Route("licenta/user")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMappingCoordinator _mapper;

        public UserController(IUserService userService, IMappingCoordinator mapper, UserManager<AppUser> userManager) : base(userManager)
        {
            _userService = userService;
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
        [HttpGet("get-all-users/{idAdmin}")]
        [SwaggerResponse(200, "User with the given id.")]
        public IActionResult GetAllUsers(bool isAdmin)
        {
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
        [HttpPatch("update")]
        public IActionResult Update(UpdateUserRequest request)
        {
            var loggedUserId = _userManager.GetUserId(HttpContext.User);
            if (request.ID != loggedUserId)
            {
                Unauthorized();
            }
            var userUpdate = _mapper.Map<UpdateUserRequest, UserUpdate>(request);

            return Ok(_userService.Update(userUpdate));
        }

        ///[Authorize]
        ///[HttpDelete("delete/{password}")]
        ///[SwaggerResponse(200, "Friends with the given string in userName.")]
        ///public IActionResult DeleteUser(string password)
        ///{
        ///var user = _userManager.GetUserId(HttpContext.User);
        ///if (password==user.password)
        ///_userService.DeleteUser(user);
        ///return Ok();
        ///}
    }
}
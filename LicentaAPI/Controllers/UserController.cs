using LicentaAPI.AppServices.Users;
using LicentaAPI.Persistence.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.Controllers
{
    [ApiController]
    [Route("licenta/user")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, UserManager<AppUser> userManager) : base(userManager)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet("find/{userName}")]
        [SwaggerResponse(200, "Users with the given string in userName.")]
        public IActionResult FindUsersByUsername(string userName)
        {
            return Ok(_userService.FindUsersByUsername(userName));
        }
    }
}
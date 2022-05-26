﻿using LicentaAPI.AppServices.Users;
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
            var loggedInUserId = _userManager.GetUserId(HttpContext.User);
            return Ok(_userService.FindUsersByUsername(userName, loggedInUserId));
        }

        [Authorize]
        [HttpGet("get/{id}")]
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
    }
}
using LicentaAPI.AppServices.Messages;
using LicentaAPI.AppServices.Messages.Model;
using LicentaAPI.Controllers.Models;
using LicentaAPI.Infrastructure.Mapper;
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
    [Route("licenta/message")]
    public class MessageController : BaseController
    {
        private readonly IMessageService _messageService;
        private readonly IMappingCoordinator _mapper;

        public MessageController(IMessageService messageService, UserManager<AppUser> userManager, IMappingCoordinator mapper) : base(userManager)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("create")]
        [SwaggerResponse(201, "Message was created.")]
        [SwaggerResponse(404, "Message can't be created.")]
        public IActionResult CreateMessage(MessageCreateRequest request)
        {
            var messageCreate = _mapper.Map<MessageCreateRequest, MessageCreate>(request);
            messageCreate.IdSender = _userManager.GetUserId(HttpContext.User);
            var message = _messageService.CreateMessage(messageCreate);

            if (message == null)
            {
                return CreateResponse(500, new { Error = "DB Error." });
            }

            return CreatedAtRoute("", new { message.ID }, message);
        }

        [Authorize]
        [HttpGet("conversation/{amount}")]
        [SwaggerResponse(201, "Conversations was uploaded.")]
        public IActionResult GetLastConversationUser(int amount)
        {
            var idUser = _userManager.GetUserId(HttpContext.User);
            return Ok(_messageService.GetAllConversationUsers(idUser, amount));
        }

        [Authorize]
        [HttpGet("conversation/user/{idOtherUser}")]
        [SwaggerResponse(201, "All messages between 2 users.")]
        public IActionResult GetAllMessagesBetweenUsers(string idOtherUser)
        {
            var idUser = _userManager.GetUserId(HttpContext.User);
            return Ok(_messageService.GetAllMessagesBetweenUsers(idUser, idOtherUser));
        }

        [Authorize]
        [HttpGet("conversation/group/{idGroup}")]
        [SwaggerResponse(201, "All group's messages.")]
        public IActionResult GetAllMessagesInGroup(string idGroup)
        {
            return Ok(_messageService.GetAllMessagesInGroup(idGroup));
        }
    }
}
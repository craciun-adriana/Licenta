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
            var bookCreate = _mapper.Map<MessageCreateRequest, MessageCreate>(request);
            var book = _messageService.CreateMessage(bookCreate);

            if (book == null)
            {
                return CreateResponse(500, new { Error = "DB Error." });
            }

            return CreatedAtRoute("", new { book.ID }, book);
        }
    }
}
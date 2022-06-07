using LicentaAPI.AppServices.Friendships;
using LicentaAPI.AppServices.Friendships.Model;
using LicentaAPI.AppServices.Models;
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
    [Route("licenta/friendship")]
    public class FriendshipController : BaseController
    {
        private readonly IFriendshipService _friendshipService;
        private readonly IMappingCoordinator _mapper;

        public FriendshipController(IFriendshipService friendshipService, UserManager<AppUser> userManager, IMappingCoordinator mapper) : base(userManager)
        {
            _friendshipService = friendshipService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("create")]
        [SwaggerResponse(201, "Friendship was created.")]
        [SwaggerResponse(404, "Friendship can't be created.")]
        public IActionResult CreateFriendship(FriendshipCreateRequest request)
        {
            var friendshipCreate = _mapper.Map<FriendshipCreateRequest, FriendshipCreate>(request);
            friendshipCreate.IdSender = _userManager.GetUserId(HttpContext.User);
            var friendship = _friendshipService.CreateFriendship(friendshipCreate);

            if (friendship == null)
            {
                return CreateResponse(500, new { Error = "DB Error." });
            }

            return CreatedAtRoute("", new { friendship.ID }, friendship);
        }

        [Authorize]
        [HttpGet("all-friendship")]
        [SwaggerResponse(200, "Friendships with the given idReceiver.")]
        [SwaggerResponse(404, "Friendship was not found.")]
        public IActionResult FindFriendshipByIdReceiver()
        {
            var idReceiver = _userManager.GetUserId(HttpContext.User);
            return Ok(_friendshipService.FindFriendshipByIdReceiver(idReceiver));
        }

        [Authorize]
        [HttpPost("accept-friendship/{idFriendship}")]
        [SwaggerResponse(200, "Friendships with the given idReceiver.")]
        [SwaggerResponse(404, "Friendship was not found.")]
        public IActionResult AcceptFriendship(string idFriendship)
        {
            var idReceiver = _userManager.GetUserId(HttpContext.User);
            var result = _friendshipService.AcceptFriendship(idFriendship, idReceiver);
            switch (result.ErrorCode)
            {
                case ErrorCode.Ok:
                    return Ok();

                case ErrorCode.NotFound:
                    return NotFound(result.Message);

                case ErrorCode.NotAuthorized:
                    return CreateResponse(401, result.Message);

                case ErrorCode.BadRequest:
                    return BadRequest(result.Message);

                default:
                    return CreateResponse(500, "ErrorCode not implemented." + result.ErrorCode);
            }
        }

        [Authorize]
        [HttpPost("block-friendship/{idFriendship}")]
        [SwaggerResponse(200, "Friendships with the given idReceiver.")]
        [SwaggerResponse(404, "Friendship was not found.")]
        public IActionResult BlockFriendship(string idFriendship)
        {
            var idReceiver = _userManager.GetUserId(HttpContext.User);
            var result = _friendshipService.BlockFriendship(idFriendship, idReceiver);
            switch (result.ErrorCode)
            {
                case ErrorCode.Ok:
                    return Ok();

                case ErrorCode.NotFound:
                    return NotFound(result.Message);

                case ErrorCode.NotAuthorized:
                    return CreateResponse(401, result.Message);

                case ErrorCode.BadRequest:
                    return BadRequest(result.Message);

                default:
                    return CreateResponse(500, "ErrorCode not implemented." + result.ErrorCode);
            }
        }

        [Authorize]
        [HttpGet("exist-friendship/{idOtherUser}")]
        [SwaggerResponse(200, "Friendships with the given idReceiver.")]
        public IActionResult GetFriendshipBetweenUsers(string idUser2)
        {
            var idUser1 = _userManager.GetUserId(HttpContext.User);
            return Ok(_friendshipService.GetFriendshipBetweenUsers(idUser1, idUser2));

            /*if (friendship != null)
            {
                return Ok(friendship);
            }
            else return null;*/
        }
    }
}
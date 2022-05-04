using LicentaAPI.AppServices.Groups;
using LicentaAPI.AppServices.Groups.Model;
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
    [Route("licenta/group")]
    public class GroupController : BaseController
    {
        private readonly IGroupService _groupService;
        private readonly IMappingCoordinator _mapper;

        public GroupController(IGroupService groupService, UserManager<AppUser> userManager, IMappingCoordinator mapper) : base(userManager)
        {
            _groupService = groupService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("create")]
        [SwaggerResponse(201, "Group was created.")]
        [SwaggerResponse(404, "Group can't be created.")]
        public IActionResult CreateGroup(GroupCreateRequest request)
        {
            var groupCreate = _mapper.Map<GroupCreateRequest, GroupCreate>(request);
            var group = _groupService.CreateGroup(groupCreate);

            if (group == null)
            {
                return CreateResponse(500, new { Error = "DB Error." });
            }

            return CreatedAtRoute("", new { group.ID }, group);
        }
    }
}
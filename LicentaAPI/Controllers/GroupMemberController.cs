using LicentaAPI.AppServices.GroupMembers;
using LicentaAPI.AppServices.GroupMembers.Model;
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
    [Route("licenta/group-member")]
    public class GroupMemberController : BaseController
    {
        private readonly IGroupMemberService _groupMemberService;
        private readonly IMappingCoordinator _mapper;

        public GroupMemberController(IGroupMemberService groupMemberService, UserManager<AppUser> userManager, IMappingCoordinator mapper) : base(userManager)
        {
            _groupMemberService = groupMemberService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("create")]
        [SwaggerResponse(201, "GroupMember was created.")]
        [SwaggerResponse(404, "GroupMember can't be created.")]
        public IActionResult CreateGroupMember(GroupMemberCreateRequest request)
        {
            var groupMemberCreate = _mapper.Map<GroupMemberCreateRequest, GroupMemberCreate>(request);
            var groupMember = _groupMemberService.CreateGroupMember(groupMemberCreate);

            if (groupMember == null)
            {
                return CreateResponse(500, new { Error = "DB Error." });
            }

            return CreatedAtRoute("", new { groupMember.ID }, groupMember);
        }
    }
}
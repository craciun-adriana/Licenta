using LicentaAPI.AppServices.GroupMembers.Model;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using System;

namespace LicentaAPI.AppServices.GroupMembers
{
    /// <summary>
    /// Concrete implementation of <see cref="IGroupMemberService"/>.
    /// </summary>
    public class GroupMemberService : IGroupMemberService
    {
        private readonly IGroupMemberRepo _groupMemberRepo;
        private readonly IMappingCoordinator _mapper;

        public GroupMemberService(IGroupMemberRepo groupMemberRepo, IMappingCoordinator mapper)
        {
            _groupMemberRepo = groupMemberRepo;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public GroupMember CreateGroupMember(GroupMemberCreate groupMemberCreate)
        {
            var groupMember = _mapper.Map<GroupMemberCreate, GroupMember>(groupMemberCreate);
            try
            {
                _groupMemberRepo.Add(groupMember);
            }
            catch (ArgumentNullException)
            {
                return null;
            }

            return groupMember;
        }
    }
}
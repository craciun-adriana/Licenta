using LicentaAPI.AppServices.GroupMembers.Model;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LicentaAPI.AppServices.GroupMembers
{
    /// <summary>
    /// Concrete implementation of <see cref="IGroupMemberService"/>.
    /// </summary>
    public class GroupMemberService : IGroupMemberService
    {
        private readonly IGroupMemberRepo _groupMemberRepo;
        private readonly IUserRepo _userRepo;
        private readonly IMappingCoordinator _mapper;

        public GroupMemberService(IGroupMemberRepo groupMemberRepo, IUserRepo userRepo, IMappingCoordinator mapper)
        {
            _groupMemberRepo = groupMemberRepo;
            _userRepo = userRepo;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public GroupMember CreateGroupMember(GroupMemberCreate groupMemberCreate)
        {
            var groupMember = _mapper.Map<GroupMemberCreate, GroupMember>(groupMemberCreate);
            groupMember.ID = Guid.NewGuid().ToString();
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

        public IEnumerable<AppUser> FindGroupMemberByIdGroup(string idGroup)
        {
            var groupMemberIds = _groupMemberRepo.FindGroupMembersByIdGroup(idGroup)
                .Select(member => member.IdUser);
            return _userRepo.GetUsersByIds(groupMemberIds);
        }
    }
}
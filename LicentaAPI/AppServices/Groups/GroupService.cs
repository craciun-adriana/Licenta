using LicentaAPI.AppServices.Groups.Model;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LicentaAPI.AppServices.Groups
{
    /// <summary>
    /// Concrete implementation of <see cref="IGroupService"/>.
    /// </summary>
    public class GroupService : IGroupService
    {
        private IGroupRepo _groupRepo;
        private IGroupMemberRepo _groupMemberRepo;
        private IMappingCoordinator _mapper;

        public GroupService(IGroupRepo groupRepo, IGroupMemberRepo groupMemberRepo, IMappingCoordinator mapper)
        {
            _groupRepo = groupRepo;
            _groupMemberRepo = groupMemberRepo;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public Group CreateGroup(GroupCreate groupCreate)
        {
            var group = _mapper.Map<GroupCreate, Group>(groupCreate);
            group.ID = Guid.NewGuid().ToString();
            group.LastMessageTimestamp = DateTime.UtcNow;
            try
            {
                _groupRepo.Add(group);
            }
            catch (ArgumentNullException)
            {
                return null;
            }

            return group;
        }

        public IEnumerable<Group> FindUserGroups(string userId)
        {
            var groupsId = _groupMemberRepo.FindUserGroupsId(userId);
            return _groupRepo.GetGroupsByIds(groupsId);
        }

        public IEnumerable<Group> FindUserGroupsByName(string name, string userId)
        {
            var groupsId = _groupMemberRepo.FindUserGroupsId(userId);
            var groups = _groupRepo.GetGroupsByIds(groupsId);
            return groups.Where(gr => gr.Name.ToUpper().Contains(name.ToUpper()));
        }

        public Group GetGroupById(string idGroup)
        {
            return _groupRepo.GetById(idGroup);
        }
    }
}
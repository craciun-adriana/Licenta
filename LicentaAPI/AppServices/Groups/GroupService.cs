using LicentaAPI.AppServices.Groups.Model;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using System;

namespace LicentaAPI.AppServices.Groups
{
    /// <summary>
    /// Concrete implementation of <see cref="IGroupService"/>.
    /// </summary>
    public class GroupService : IGroupService
    {
        private IGroupRepo _groupRepo;
        private IMappingCoordinator _mapper;

        public GroupService(IGroupRepo groupRepo, IMappingCoordinator mapper)
        {
            _groupRepo = groupRepo;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public Group CreateGroup(GroupCreate groupCreate)
        {
            var group = _mapper.Map<GroupCreate, Group>(groupCreate);
            group.ID = Guid.NewGuid().ToString();
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
    }
}
﻿using LicentaAPI.AppServices.Groups.Model;
using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

namespace LicentaAPI.AppServices.Groups
{
    /// <summary>
    /// Interface providing contracts for <see cref="Group"/> related operations.
    /// </summary>
    public interface IGroupService
    {
        /// <summary>
        /// Create a group.
        /// </summary>
        /// <param name="groupCreate">Details about a group.</param>
        /// <returns>The created group or null if it was not created.</returns>
        public Group CreateGroup(GroupCreate groupCreate);

        public Group GetGroupById(string idGroup);

        public IEnumerable<Group> FindUserGroupsByName(string name, string userId);

        public IEnumerable<Group> FindUserGroups(string userId);
    }
}
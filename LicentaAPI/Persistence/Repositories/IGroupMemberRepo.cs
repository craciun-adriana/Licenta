using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

namespace LicentaAPI.Persistence.Repositories
{
    /// <summary>
    /// Interface providing contracts for <see cref="GroupMember"/>.
    /// </summary>
    public interface IGroupMemberRepo : IGenericRepo<GroupMember>
    {
        /// <summary>
        /// Retrieves the group members that have the given id group.
        /// </summary>
        /// <param name="idGroup">The id of the group that user is searching for.</param>
        /// <returns>A list of group members that have the given idGroup.</returns>
        public IEnumerable<GroupMember> FindGroupMembersByIdGroup(string idGroup);
    }
}
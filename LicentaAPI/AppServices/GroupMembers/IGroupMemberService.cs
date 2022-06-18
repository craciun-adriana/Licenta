using LicentaAPI.AppServices.GroupMembers.Model;
using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

namespace LicentaAPI.AppServices.GroupMembers
{
    /// <summary>
    /// Interface providing contracts for <see cref="GroupMember"/> related operations.
    /// </summary>
    public interface IGroupMemberService
    {
        /// <summary>
        /// Create a GroupMember.
        /// </summary>
        /// <param name="groupMemberCreate">Details about a GroupMemeber.</param>
        /// <returns>The created GroupMember or null if it was not created.</returns>
        public GroupMember CreateGroupMember(GroupMemberCreate groupMemberCreate);

        public IEnumerable<AppUser> FindGroupMemberByIdGroup(string groupId);
    }
}
using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

namespace LicentaAPI.Persistence.Repositories
{
    /// <summary>
    /// Interface providing contracts for <see cref="Group"/> repository.
    /// </summary>
    public interface IGroupRepo : IGenericRepo<Group>
    {
        /// <summary>
        /// Retrieves groups that have the given name.
        /// </summary>
        /// <param name="name">The name of the group that user is searching for.</param>
        /// <returns>All groups that have the given string in name.</returns>
        public IEnumerable<Group> FindGroupByName(string name);

        /// <summary>
        /// Retrieves groups that have the given idMember.
        /// </summary>
        /// <param name="idMember"></param>
        /// <returns>All groups in which a user is a member.</returns>
        public IEnumerable<Group> FindGroupsByMemberId(string idMember);

        public IEnumerable<Group> FindGroupsByLastMessage(string idUser, int amount);
    }
}
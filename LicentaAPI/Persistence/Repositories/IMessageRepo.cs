using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

namespace LicentaAPI.Persistence.Repositories
{
    /// <summary>
    /// Interface providing contracts for <see cref="Message"/> repository.
    /// </summary>
    public interface IMessageRepo : IGenericRepo<Message>
    {
        /// <summary>
        /// Retrieves messages that have the given idUsers.
        /// </summary>
        /// <param name="idUser1">The id of the first user.</param>
        /// <param name="idUser2">The id of the second user.</param>
        /// <returns>All messages sent between 2 users that have the given idUser.</returns>
        public IEnumerable<Message> FindMessagesBetweenUsers(string idUser1, string idUser2);

        /// <summary>
        /// Retrieves messages that have the given idGroup.
        /// </summary>
        /// <param name="idGroup">The id of the group.</param>
        /// <returns>All messages sent in the group with given idGroup.</returns>
        public IEnumerable<Message> FindMessagesInGroup(string idGroup);

        public IEnumerable<string> GetLastConversationUsers(string idUser, int amount);
    }
}
using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

namespace LicentaAPI.Persistence.Repositories
{
    /// <summary>
    /// Providing contracts for <see cref="Friendship"/> repository.
    /// </summary>
    public interface IFriendshipRepo : IGenericRepo<Friendship>
    {
        /// <summary>
        /// Retrieves the friendship that have the given idReceiver.
        /// </summary>
        /// <param name="idReceiver">The IdReceiver of the friendship that user is searching for.</param>
        /// <returns></returns>
        public IEnumerable<Friendship> FindFriendshipByIdReceiver(string idReceiver);
    }
}
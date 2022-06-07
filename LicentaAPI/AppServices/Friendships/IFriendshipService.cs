using LicentaAPI.AppServices.Friendships.Model;
using LicentaAPI.AppServices.Models;
using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

namespace LicentaAPI.AppServices.Friendships
{
    /// <summary>
    /// Interface providing contracts for <see cref="Friendship"/> related operation.
    /// </summary>
    public interface IFriendshipService
    {
        /// <summary>
        /// Create a friendship.
        /// </summary>
        /// <param name="friendshipCreate">Details about a friendship.</param>
        /// <returns>The created friendship or null if it was not created.</returns>
        public Friendship CreateFriendship(FriendshipCreate friendshipCreate);

        public IEnumerable<Friendship> FindFriendshipByIdReceiver(string idReceiver);

        public Error AcceptFriendship(string idFriendship, string idReceiver);

        public Error BlockFriendship(string idFriendship, string idReceiver);

        public Friendship GetFriendshipBetweenUsers(string idUser1, string idUser2);
    }
}
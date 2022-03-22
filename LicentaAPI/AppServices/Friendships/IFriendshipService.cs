using LicentaAPI.AppServices.Friendships.Model;
using LicentaAPI.Persistence.Models;

namespace LicentaAPI.AppServices.Friendships
{
    /// <summary>
    /// Interface providing contracts for <see cref="Friendship"/> related opeartion.
    /// </summary>
    internal interface IFriendshipService
    {
        /// <summary>
        /// Create a friendship.
        /// </summary>
        /// <param name="friendshipCreate">Details about a friendship.</param>
        /// <returns>The created friendship or null if it was not created.</returns>
        public Friendship CreateFriendship(FriendshipCreate friendshipCreate);
    }
}
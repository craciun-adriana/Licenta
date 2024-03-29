﻿using LicentaAPI.Persistence.Models;
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
        /// <returns>A list of friendships that have the given idReceiver.</returns>
        public IEnumerable<Friendship> FindFriendshipRequestByIdReceiver(string idReceiver);

        public Friendship GetFriendshipBetweenUsers(string idUser1, string idUser2);

        public IEnumerable<string> GetFriendsIdForUser(string idUser);
    }
}
﻿using LicentaAPI.AppServices.Messages.Model;
using LicentaAPI.AppServices.Models;
using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

namespace LicentaAPI.AppServices.Messages
{
    /// <summary>
    /// Interface providing contracts for <see cref="Message"/> related operations.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Create a group.
        /// </summary>
        /// <param name="messageCreate">Contains details about a message.</param>
        /// <returns>The created message or null if it was not created.</returns>
        public Message CreateMessage(MessageCreate messageCreate);

        public IEnumerable<MessageDTO> GetAllMessagesBetweenUsers(string idUser1, string idUser2);

        public IEnumerable<MessageDTO> GetAllMessagesInGroup(string idGroup);

        public IEnumerable<PublicUserDetails> GetLastConversationsUsers(string iduser, int amound);

        public IEnumerable<Group> GetLastConversationsGroups(string iduser, int amound);
    }
}
using LicentaAPI.AppServices.Messages.Model;
using LicentaAPI.Persistence.Models;

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
    }
}
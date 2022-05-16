using LicentaAPI.AppServices.Messages.Model;
using LicentaAPI.AppServices.Models;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;

namespace LicentaAPI.AppServices.Messages
{
    /// <summary>
    /// Concrete implementation of <see cref="IMessageService"/>.
    /// </summary>
    public class MessageService : IMessageService
    {
        private readonly IMessageRepo _messageRepo;
        private readonly IUserRepo _userRepo;
        private readonly IMappingCoordinator _mapper;

        public MessageService(IMessageRepo messageRepo, IUserRepo userRepo, IMappingCoordinator mapper)
        {
            _messageRepo = messageRepo;
            _userRepo = userRepo;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public Message CreateMessage(MessageCreate messageCreate)
        {
            var message = _mapper.Map<MessageCreate, Message>(messageCreate);
            message.ID = Guid.NewGuid().ToString();
            try
            {
                _messageRepo.Add(message);
            }
            catch (ArgumentNullException)
            {
                return null;
            }

            return message;
        }

        public IEnumerable<PublicUserDetails> GetAllConversationUsers(string idUser, int amount)
        {
            var userIds = _messageRepo.GetLastConversationUsers(idUser, amount);
            var users = _userRepo.GetUsersByIds(userIds);
            return _mapper.Map<AppUser, PublicUserDetails>(users);
        }

        public IEnumerable<Message> GetAllMessagesBetweenUsers(string idUser1, string idUser2)
        {
            return _messageRepo.FindMessagesBetweenUsers(idUser1, idUser2);
        }

        public IEnumerable<Message> GetAllMessagesInGroup(string idGroup)
        {
            return _messageRepo.FindMessagesInGroup(idGroup);
        }
    }
}
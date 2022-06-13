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
        private readonly IGroupRepo _groupRepo;
        private readonly IUserRepo _userRepo;
        private readonly IMappingCoordinator _mapper;

        public MessageService(IMessageRepo messageRepo, IUserRepo userRepo, IGroupRepo groupRepo, IMappingCoordinator mapper)
        {
            _messageRepo = messageRepo;
            _groupRepo = groupRepo;
            _userRepo = userRepo;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public Message CreateMessage(MessageCreate messageCreate)
        {
            var message = _mapper.Map<MessageCreate, Message>(messageCreate);
            message.ID = Guid.NewGuid().ToString();
            message.SendTime = DateTime.UtcNow;
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

        public IEnumerable<PublicUserDetails> GetLastConversationsUsers(string idUser, int amount)
        {
            var userIds = _messageRepo.GetLastConversationsUsers(idUser, amount);
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

        public IEnumerable<Group> GetLastConversationsGroups(string idUser, int amount)
        {
            return _groupRepo.FindGroupsByLastMessage(idUser, amount);
        }
    }
}
using LicentaAPI.AppServices.Messages.Model;
using LicentaAPI.AppServices.Models;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

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

                if (message.IdGroup != null)
                {
                    var group = _groupRepo.GetById(message.IdGroup);
                    group.LastMessageTimestamp = message.SendTime;
                    _groupRepo.Update(group);
                }
            }
            catch (ArgumentNullException)
            {
                return null;
            }

            return message;
        }

        public IEnumerable<PublicUserDetails> GetLastConversationsUsers(string idUser, int amount)
        {
            var userIds = _messageRepo.GetLastConversationsUsers(idUser, amount).ToList();
            var users = _userRepo.GetUsersByIds(userIds)
                .OrderBy(u => userIds.IndexOf(u.Id));
            return _mapper.Map<AppUser, PublicUserDetails>(users);
        }

        public IEnumerable<MessageDTO> GetAllMessagesBetweenUsers(string idUser1, string idUser2)
        {
            var messages = _messageRepo.FindMessagesBetweenUsers(idUser1, idUser2);
            var messageDTO = _mapper.Map<Message, MessageDTO>(messages);

            foreach (var item in messageDTO)
            {
                item.NameSender = _userRepo.GetUserById(item.IdSender).UserName;
            }
            return messageDTO;
        }

        public IEnumerable<MessageDTO> GetAllMessagesInGroup(string idGroup)
        {
            var messages = _messageRepo.FindMessagesInGroup(idGroup);
            var messageDTO = _mapper.Map<Message, MessageDTO>(messages);

            foreach (var item in messageDTO)
            {
                item.NameSender = _userRepo.GetUserById(item.IdSender).UserName;
            }
            return messageDTO;
        }

        public IEnumerable<Group> GetLastConversationsGroups(string idUser, int amount)
        {
            return _groupRepo.FindGroupsByLastMessage(idUser, amount);
        }
    }
}
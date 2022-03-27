using LicentaAPI.AppServices.Messages.Model;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.AppServices.Messages
{
    /// <summary>
    /// Concrete implementation of <see cref="IMessageService"/>.
    /// </summary>
    public class MessageService : IMessageService
    {
        private readonly IMessageRepo _messageRepo;
        private readonly IMappingCoordinator _mapper;

        public MessageService(IMessageRepo messageRepo, IMappingCoordinator mapper)
        {
            _messageRepo = messageRepo;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public Message CreateMessage(MessageCreate messageCreate)
        {
            var message = _mapper.Map<MessageCreate, Message>(messageCreate);
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
    }
}
﻿using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LicentaAPI.Persistence.Repositories
{
    /// <summary>
    /// Concrete implementation of <see cref="Message"/> using Entity Framework.
    /// </summary>
    public class EFMessageRepository : IMessageRepo
    {
        public AppDbContext _dbContext;

        public EFMessageRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public void Add(Message entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Messages.Add(entity);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(Message entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Messages.Remove(entity);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public IEnumerable<Message> FindMessagesBetweenUsers(string idUser1, string idUser2)
        {
            if (string.IsNullOrEmpty(idUser1))
            {
                throw new ArgumentNullException(nameof(idUser1));
            }

            if (string.IsNullOrEmpty(idUser2))
            {
                throw new ArgumentNullException(nameof(idUser2));
            }

            return _dbContext.Messages.Where(message =>
                (message.IdReceiver.Equals(idUser1) && message.IdSender.Equals(idUser2))
                || (message.IdReceiver.Equals(idUser2) && message.IdSender.Equals(idUser1))
            );
        }

        /// <inheritdoc/>
        public IEnumerable<Message> FindMessagesInGroup(string idGroup)
        {
            if (string.IsNullOrEmpty(idGroup))
            {
                throw new ArgumentNullException(nameof(idGroup));
            }
            return _dbContext.Messages.Where(message => message.IdGroup.Equals(idGroup));
        }

        /// <inheritdoc/>
        public IEnumerable<Message> GetAll()
        {
            return _dbContext.Messages.ToList();
        }

        /// <inheritdoc/>
        public Message GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _dbContext.Messages.FirstOrDefault(message => message.ID.Equals(id));
        }

        /// <inheritdoc/>
        public IEnumerable<Message> Query(PaginationQuery paginationQuery)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Update(Message entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Messages.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
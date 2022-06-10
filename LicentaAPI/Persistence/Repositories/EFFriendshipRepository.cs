using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LicentaAPI.Persistence.Repositories
{
    /// <summary>
    /// Concrete implementation of <see cref="Friendship"/> using Entity Framework.
    /// </summary>
    public class EFFriendshipRepository : IFriendshipRepo
    {
        private AppDbContext _dbContext;

        public EFFriendshipRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public void Add(Friendship entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Friendships.Add(entity);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(Friendship entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbContext.Friendships.Remove(entity);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public IEnumerable<Friendship> FindFriendshipRequestByIdReceiver(string idReceiver)
        {
            if (string.IsNullOrEmpty(idReceiver))
            {
                throw new ArgumentNullException(idReceiver);
            }
            return _dbContext.Friendships.Where(friendship => friendship.IdReceiver.Equals(idReceiver) && friendship.Status == FriendshipStatus.Pending).ToList();
        }

        /// <inheritdoc/>
        public IEnumerable<Friendship> GetAll()
        {
            return _dbContext.Friendships.ToList();
        }

        /// <inheritdoc/>
        public Friendship GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _dbContext.Friendships.FirstOrDefault(friendship => friendship.ID.Equals(id));
        }

        /// <inheritdoc/>
        public IEnumerable<Friendship> Filter(PaginationQuery paginationQuery)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Update(Friendship entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbContext.Friendships.Update(entity);
            _dbContext.SaveChanges();
        }

        public Friendship GetFriendshipBetweenUsers(string idUser1, string idUser2)
        {
            return _dbContext.Friendships.FirstOrDefault(f =>
                (f.IdSender == idUser1 && f.IdReceiver == idUser2) 
                || (f.IdSender == idUser2 && f.IdReceiver == idUser1));
        }

        public IEnumerable<string> GetFriendsIdForUser(string idUser)
        {
            var listIdFriendsR = _dbContext.Friendships.Where(f => f.IdReceiver == idUser)
                .Select(f => f.IdSender);
            var listFriendsS = _dbContext.Friendships.Where(f => f.IdSender == idUser)
                .Select(f => f.IdReceiver);
            return listIdFriendsR.Concat(listFriendsS).ToList();
        }
    }
}
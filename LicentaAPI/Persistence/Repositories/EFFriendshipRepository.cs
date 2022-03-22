using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.Persistence.Repositories
{
    public class EFFriendshipRepository : IFriendshipRepo
    {
        private AppDbContext _dbContext;

        public EFFriendshipRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        ///<inheritdoc/>
        public void Add(Friendship entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Friendships.Add(entity);
            _dbContext.SaveChanges();
        }

        ///<inheritdoc/>
        public void Delete(Friendship entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbContext.Friendships.Remove(entity);
            _dbContext.SaveChanges();
        }

        ///<inheritdoc/>
        public IEnumerable<Friendship> FindFriendshipByIdReceiver(string idReceiver)
        {
            if (string.IsNullOrEmpty(idReceiver))
            {
                throw new ArgumentNullException(idReceiver);
            }
            return _dbContext.Friendships.Where(friendship => friendship.IdReceiver.Equals(idReceiver))
                                         .Where(friendship => friendship.Status == FriendshipStatus.Pending);
        }

        ///<inheritdoc/>
        public Friendship GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _dbContext.Friendships.FirstOrDefault(friendship => friendship.ID.Equals(id));
        }

        ///<inheritdoc/>
        public IEnumerable<Friendship> Query(PaginationQuery paginationQuery)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public void Update(Friendship entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbContext.Friendships.Update(entity);
        }
    }
}
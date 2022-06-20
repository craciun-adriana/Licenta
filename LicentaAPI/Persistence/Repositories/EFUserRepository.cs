using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LicentaAPI.Persistence.Repositories
{
    public class EFUserRepository : IUserRepo
    {
        private AppDbContext _dbContext;

        public EFUserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        ///<inheritdoc/>
        public IEnumerable<AppUser> GetUsersByIds(IEnumerable<string> ids)
        {
            return _dbContext.Users.Where(user => ids.Contains(user.Id));
        }

        ///<inheritdoc/>
        public IEnumerable<AppUser> FindUsersByUsername(string username)
        {
            return _dbContext.Users.Where(user => user.UserName.Contains(username));
        }

        ///<inheritdoc/>
        public AppUser GetUserById(string idUser)
        {
            return _dbContext.Users.FirstOrDefault(user => user.Id.Equals(idUser));
        }

        ///<inheritdoc/>
        public IEnumerable<AppUser> FindFriendsByUsername(string username, IEnumerable<string> listFriendsId)
        {
            return _dbContext.Users
                .Where(user => listFriendsId.Contains(user.Id))
                .Where(user => user.UserName.ToUpper().Contains(username.ToUpper()))
                .ToList();
        }

        public void Update(AppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Users.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(AppUser entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Users.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
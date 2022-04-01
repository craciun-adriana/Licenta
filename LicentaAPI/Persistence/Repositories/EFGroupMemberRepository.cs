using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LicentaAPI.Persistence.Repositories
{
    /// <summary>
    /// Concrete implementation of <see cref="GroupMember"/> using Entity Framework.
    /// </summary>
    public class EFGroupMemberRepository : IGroupMemberRepo
    {
        private AppDbContext _dbContext;

        public EFGroupMemberRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public void Add(GroupMember entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.GroupMembers.Add(entity);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(GroupMember entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.GroupMembers.Remove(entity);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public IEnumerable<GroupMember> FindGroupMembersByIdGroup(string idGroup)
        {
            if (string.IsNullOrEmpty(idGroup))
            {
                throw new ArgumentNullException(nameof(idGroup));
            }

            return _dbContext.GroupMembers.Where(groupMember => groupMember.IdGroup.Equals(idGroup)).ToList();
        }

        /// <inheritdoc/>
        public IEnumerable<GroupMember> GetAll()
        {
            return _dbContext.GroupMembers.ToList();
        }

        /// <inheritdoc/>
        public GroupMember GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _dbContext.GroupMembers.FirstOrDefault(groupMember => groupMember.ID.Equals(id));
        }

        /// <inheritdoc/>
        public IEnumerable<GroupMember> Query(PaginationQuery paginationQuery)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Update(GroupMember entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.GroupMembers.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
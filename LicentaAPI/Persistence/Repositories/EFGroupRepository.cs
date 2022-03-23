using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.Persistence.Repositories
{
    public class EFGroupRepository : IGroupRepo
    {
        private AppDbContext _dbContext;

        public EFGroupRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        ///<inheritdoc/>
        public void Add(Group entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Groups.Add(entity);
            _dbContext.SaveChanges();
        }

        ///<inheritdoc/>
        public void Delete(Group entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Groups.Remove(entity);
            _dbContext.SaveChanges();
        }

        ///<inheritdoc/>
        public IEnumerable<Group> FindGroupByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            return _dbContext.Groups.Where(group => group.Name.Contains(name)).ToList();
        }

        ///<inheritdoc/>
        public Group GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _dbContext.Groups.FirstOrDefault(group => group.ID.Equals(id));
        }

        ///<inheritdoc/>
        public IEnumerable<Group> Query(PaginationQuery paginationQuery)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public void Update(Group entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Groups.Update(entity);
        }
    }
}
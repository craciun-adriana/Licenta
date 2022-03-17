using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LicentaAPI.Persistence.Repositories
{
    public class EFSeriesRepository : ISeriesRepo
    {
        private AppDbContext _dbContext;

        public EFSeriesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        ///<inheritdoc/>
        public void Add(Series entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Series.Add(entity);
            _dbContext.SaveChanges();
        }

        ///<inheritdoc/>
        public void Delete(Series entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Series.Remove(entity);
            _dbContext.SaveChanges();
        }

        ///<inheritdoc/>
        public IEnumerable<Series> FindSeriesByTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            return _dbContext.Series.Where(series => series.Title.Contains(title)).ToList();
        }

        ///<inheritdoc/>
        public Series GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _dbContext.Series.FirstOrDefault(series => series.ID.Equals(id));
        }

        ///<inheritdoc/>
        public IEnumerable<Series> Query(PaginationQuery paginationQuery)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public void Update(Series entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
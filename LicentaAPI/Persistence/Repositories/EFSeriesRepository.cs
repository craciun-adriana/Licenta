using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LicentaAPI.Persistence.Repositories
{
    /// <summary>
    /// Concrete implementation of <see cref="Series"/> using Entity Framework.
    /// </summary>
    public class EFSeriesRepository : ISeriesRepo
    {
        private AppDbContext _dbContext;

        public EFSeriesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public void Add(Series entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Series.Add(entity);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(Series entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Series.Remove(entity);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public IEnumerable<Series> FindSeriesByTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            return _dbContext.Series.Where(series => series.Title.Contains(title)).ToList();
        }

        /// <inheritdoc/>
        public IEnumerable<Series> GetAll()
        {
            return _dbContext.Series.ToList();
        }

        /// <inheritdoc/>
        public Series GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _dbContext.Series.FirstOrDefault(series => series.ID.Equals(id));
        }

        /// <inheritdoc/>
        public IEnumerable<Series> Filter(PaginationQuery paginationQuery)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Update(Series entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Series.Update(entity);
            _dbContext.SaveChanges();
        }

        ///<inheritdoc/>
        public IEnumerable<Series> FindSeriesByGenre(Genre genre)
        {
            return _dbContext.Series.Where(series => series.Genre.Equals(genre)).ToList();
        }
    }
}
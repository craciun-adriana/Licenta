using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LicentaAPI.Persistence.Repositories
{
    /// <summary>
    /// Concrete implementation of <see cref="ReviewSeries"/> using Entity Framework.
    /// </summary>
    public class EFReviewSeriesRepository : IReviewSeriesRepo
    {
        private AppDbContext _dbContext;

        public EFReviewSeriesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public void Add(ReviewSeries entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.ReviewSeries.Add(entity);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(ReviewSeries entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.ReviewSeries.Remove(entity);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public IEnumerable<ReviewSeries> FindReviewSeriesByIdSeries(string idSeries)
        {
            if (string.IsNullOrEmpty(idSeries))
            {
                throw new ArgumentNullException(nameof(idSeries));
            }

            return _dbContext.ReviewSeries.Where(reviewSeries => reviewSeries.IdSeries.Equals(idSeries));
        }

        /// <inheritdoc/>
        public ReviewSeries GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _dbContext.ReviewSeries.FirstOrDefault(reviewSeries => reviewSeries.ID.Equals(id));
        }

        /// <inheritdoc/>
        public IEnumerable<ReviewSeries> Query(PaginationQuery paginationQuery)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Update(ReviewSeries entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.ReviewSeries.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
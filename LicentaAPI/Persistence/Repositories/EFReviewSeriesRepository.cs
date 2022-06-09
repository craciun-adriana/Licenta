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
        public IEnumerable<ReviewSeries> GetAll()
        {
            return _dbContext.ReviewSeries.ToList();
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

        public IEnumerable<ReviewSeries> GetByStatus(Status status, string idUser)
        {
            return _dbContext.ReviewSeries.Where(reviewSeries => (reviewSeries.Status.Equals(status)) && (reviewSeries.IdUser.Equals(idUser))).ToList();
        }

        /// <inheritdoc/>
        public IEnumerable<ReviewSeries> Filter(PaginationQuery paginationQuery)
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

        public ReviewSeries GetReviewSeriesByIdSeriesAndUser(string idSeries, string idUser)
        {
            if (idSeries == null)
            {
                throw new ArgumentNullException(nameof(idSeries));
            }
            else if (idUser == null)
            {
                throw new ArgumentNullException(nameof(idUser));
            }

            return _dbContext.ReviewSeries
                .FirstOrDefault(reviewSeries => (reviewSeries.IdSeries.Equals(idSeries)) && (reviewSeries.IdUser.Equals(idUser)));
        }

        public IEnumerable<ReviewSeries> GetReviewSeriesCompletedByIdUser(string idUser)
        {
            return _dbContext.ReviewSeries.Where(reviewSeries => reviewSeries.IdUser.Equals(idUser) && reviewSeries.Status.Equals(Status.Completed));
        }
    }
}
using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LicentaAPI.Persistence.Repositories
{
    /// <summary>
    /// Concrete implementation of <see cref="ReviewBook"/> using Entity Framework.
    /// </summary>
    public class EFReviewBookRepository : IReviewBookRepo
    {
        private AppDbContext _dbContext;

        public EFReviewBookRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public void Add(ReviewBook entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.ReviewBooks.Add(entity);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(ReviewBook entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.ReviewBooks.Remove(entity);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public IEnumerable<ReviewBook> FindReviewBookByIdBook(string idBook)
        {
            if (string.IsNullOrEmpty(idBook))
            {
                throw new ArgumentNullException(nameof(idBook));
            }

            return _dbContext.ReviewBooks.Where(reviewBook => reviewBook.IdBook.Equals(idBook));
        }

        /// <inheritdoc/>
        public IEnumerable<ReviewBook> GetAll()
        {
            return _dbContext.ReviewBooks.ToList();
        }

        /// <inheritdoc/>
        public ReviewBook GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _dbContext.ReviewBooks.FirstOrDefault(reviewBook => reviewBook.ID.Equals(id));
        }

        public IEnumerable<ReviewBook> GetByStatus(Status status)
        {
            return _dbContext.ReviewBooks.Where(reviewBook => reviewBook.Status.Equals(status)).ToList();
        }

        /// <inheritdoc/>
        public IEnumerable<ReviewBook> Filter(PaginationQuery paginationQuery)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Update(ReviewBook entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.ReviewBooks.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
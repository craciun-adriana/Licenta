using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LicentaAPI.Persistence.Repositories
{
    /// <summary>
    /// Concrete implementation of <see cref="ReviewFilm"/> using Entity Framework.
    /// </summary>
    public class EFReviewFilmRepository : IReviewFilmRepo
    {
        private AppDbContext _dbContext;

        public EFReviewFilmRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public void Add(ReviewFilm entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.ReviewFilms.Add(entity);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(ReviewFilm entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.ReviewFilms.Remove(entity);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public IEnumerable<ReviewFilm> FindReviewFilmByIdFilm(string idFilm)
        {
            if (string.IsNullOrEmpty(idFilm))
            {
                throw new ArgumentNullException(nameof(idFilm));
            }

            return _dbContext.ReviewFilms.Where(reviewF =>
            (reviewF.IdFilm.Equals(idFilm)) && (!string.IsNullOrEmpty(reviewF.Review) || reviewF.Grade.HasValue));
        }

        /// <inheritdoc/>
        public IEnumerable<ReviewFilm> GetAll()
        {
            return _dbContext.ReviewFilms.ToList();
        }

        /// <inheritdoc/>
        public ReviewFilm GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _dbContext.ReviewFilms.FirstOrDefault(reviewFilm => reviewFilm.ID.Equals(id));
        }

        public IEnumerable<ReviewFilm> GetByStatus(Status status, string idUser)
        {
            return _dbContext.ReviewFilms.Where(reviewFilm => (reviewFilm.Status.Equals(status)) && (reviewFilm.IdUser.Equals(idUser))).ToList();
        }

        /// <inheritdoc/>
        public IEnumerable<ReviewFilm> Filter(PaginationQuery paginationQuery)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Update(ReviewFilm entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.ReviewFilms.Update(entity);
            _dbContext.SaveChanges();
        }

        public ReviewFilm GetReviewFilmByIdFilmAndUser(string idFilm, string idUser)
        {
            if (idFilm == null)
            {
                throw new ArgumentNullException(nameof(idFilm));
            }
            else if (idUser == null)
            {
                throw new ArgumentNullException(nameof(idUser));
            }

            return _dbContext.ReviewFilms
                .FirstOrDefault(reviewFilm => (reviewFilm.IdFilm.Equals(idFilm)) && (reviewFilm.IdUser.Equals(idUser)));
        }

        public IEnumerable<ReviewFilm> GetReviewFilmCompletedByIdUser(string idUser)
        {
            return _dbContext.ReviewFilms.Where(reviewFilm => reviewFilm.IdUser.Equals(idUser) && reviewFilm.Status.Equals(Status.Completed));
        }
    }
}
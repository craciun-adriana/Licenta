using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LicentaAPI.Persistence.Repositories
{
    /// <summary>
    /// Concrete implementation of <see cref="Film"/> using Entity Framework.
    /// </summary>
    public class EFFilmRepository : IFilmRepo
    {
        private AppDbContext _dbContext;

        public EFFilmRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public void Add(Film entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbContext.Films.Add(entity);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(Film entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbContext.Films.Remove(entity);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public IEnumerable<Film> FindFilmByTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            return _dbContext.Films.Where(film => film.Title.Contains(title)).ToList();
        }

        /// <inheritdoc/>
        public IEnumerable<Film> GetAll()
        {
            return _dbContext.Films.ToList();
        }

        /// <inheritdoc/>
        public Film GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            return _dbContext.Films.FirstOrDefault(film => film.ID.Equals(id));
        }

        /// <inheritdoc/>
        public IEnumerable<Film> Filter(PaginationQuery paginationQuery)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Update(Film entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Films.Update(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Film> FindFilmByGenre(Genre genre)
        {
            /*if (genre!=null)
          {
              throw new ArgumentNullException(nameof(genre));
          }*/
            return _dbContext.Films.Where(film => film.Genre.Equals(genre)).ToList();
        }
    }
}
using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.Persistence.Repositories
{
    public class EFFilmRepository : IFilmRepo
    {
        private AppDbContext _dbContext;

        public EFFilmRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        ///<inheritdoc/>
        public void Add(Film entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbContext.Films.Add(entity);
            _dbContext.SaveChanges();
        }

        ///<inheritdoc/>
        public void Delete(Film entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbContext.Films.Remove(entity);
            _dbContext.SaveChanges();
        }

        ///<inheritdoc/>
        public IEnumerable<Film> FindFilmByTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            return _dbContext.Films.Where(film => film.Title.Contains(title)).ToList();
        }

        ///<inheritdoc/>
        public Film GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            return _dbContext.Films.FirstOrDefault(film => film.ID.Equals(id));
        }

        ///<inheritdoc/>
        public IEnumerable<Film> Query(PaginationQuery paginationQuery)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public void Update(Film entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Films.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LicentaAPI.Persistence.Repositories
{
    /// <summary>
    /// Concrete implementation of <see cref="Book"/> using Entity Framework.
    /// </summary>
    public class EFBookRepository : IBookRepo
    {
        private AppDbContext _dbContext;

        public EFBookRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc />
        public void Add(Book entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Books.Add(entity);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc />
        public void Delete(Book entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Books.Remove(entity);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc />
        public IEnumerable<Book> FindBookByTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            return _dbContext.Books.Where(book => book.Title.Contains(title)).ToList();
        }

        /// <inheritdoc/>
        public IEnumerable<Book> GetAll()
        {
            return _dbContext.Books.ToList();
        }

        /// <inheritdoc />
        public Book GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _dbContext.Books.FirstOrDefault(book => book.ID.Equals(id));
        }

        /// <inheritdoc />
        public IEnumerable<Book> Query(PaginationQuery paginationQuery)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Update(Book entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Books.Update(entity);
        }
    }
}
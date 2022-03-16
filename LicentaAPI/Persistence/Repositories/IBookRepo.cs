using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

namespace LicentaAPI.Persistence.Repositories
{
    /// <summary>
    /// Interface providing contracts for <see cref="Book"/> repository.
    /// </summary>
    public interface IBookRepo : IGenericRepo<Book>
    {
        /// <summary>
        /// Retrieves books that have the given title.
        /// </summary>
        /// <param name="title">The title of the book that the user is searching for.</param>
        /// <returns></returns>
        public IEnumerable<Book> FindBookByTitle(string title);
    }
}
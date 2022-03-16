using LicentaAPI.AppServices.Books.Models;
using LicentaAPI.Persistence.Models;

namespace LicentaAPI.AppServices.Books
{
    /// <summary>
    /// Interface providing contracts for <see cref="Book"/> related operations.
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Creates a book.
        /// </summary>
        /// <param name="bookCreate">Details about a book.</param>
        /// <returns>the created book or null if it was not created.</returns>
        public Book CreateBook(BookCreate bookCreate);
    }
}
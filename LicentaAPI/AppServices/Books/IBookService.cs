using LicentaAPI.AppServices.Books.Models;
using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

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
        /// <returns>The created book or null if it was not created.</returns>
        public Book CreateBook(BookCreate bookCreate);

        /// <summary>
        /// Returns a book with the given id.
        /// </summary>
        /// <param name="idBook">The id of the book.</param>
        /// <returns>A book with the given id or null if it was not found.</returns>
        public Book GetBookById(string idBook);

        /// <summary>
        /// Deletes a book with the given id.
        /// </summary>
        /// <param name="idBook">The id of the book to be deleted.</param>
        public void DeleteBook(string idBook);

        /// <summary>
        /// Returns books that have the given string in the title.
        /// </summary>
        /// <param name="title">The title of the book that the user is searching for.</param>
        /// <returns>A list of books that contain the given string in title.</returns>
        public IEnumerable<Book> FindBookByTitle(string title);

        /// <summary>
        /// Updates a book.
        /// </summary>
        /// <param name="bookUpdate">The book that contains the new details.</param>
        /// <returns>The updated book or null if it was not updated and the error.</returns>
        public BookUpdateResult UpdateBook(BookUpdate bookUpdate);
    }
}
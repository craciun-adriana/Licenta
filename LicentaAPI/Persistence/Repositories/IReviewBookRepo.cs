using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

namespace LicentaAPI.Persistence.Repositories
{
    /// <summary>
    /// Interface providing contracts for <see cref="ReviewBook"/>
    /// </summary>
    public interface IReviewBookRepo : IGenericRepo<ReviewBook>
    {
        /// <summary>
        /// Retrieves the ReviewBook that have the given idBook.
        /// </summary>
        /// <param name="idBook">The id of the book that user is searching for.</param>
        /// <returns>All reviews received by a book with given idBook.</returns>
        public IEnumerable<ReviewBook> FindReviewBookByIdBook(string idBook);

        public IEnumerable<ReviewBook> GetByStatus(Status status, string idUser);

        public IEnumerable<ReviewBook> GetReviewBookCompletedByIdUser(string idUser);

        public ReviewBook GetReviewBookByIdBookAndUser(string idBook, string idUser);
    }
}
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
        /// <param name="idBook">The id of the review book that user is searching for.</param>
        /// <returns></returns>
        public IEnumerable<ReviewBook> FindReviewBookByIdBook(string idBook);
    }
}
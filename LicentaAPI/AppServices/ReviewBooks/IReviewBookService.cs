using LicentaAPI.AppServices.ReviewBooks.Model;
using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.AppServices.ReviewBooks
{
    /// <summary>
    /// Interface providing contracts for <see cref="ReviewBook"/> related operations.
    /// </summary>
    public interface IReviewBookService
    {
        /// <summary>
        /// Create a ReviewBook.
        /// </summary>
        /// <param name="reviewBookCreate">Details aboul a reviewBook.</param>
        /// <returns>The created ReviewBook or null if ot was not created.</returns>
        public ReviewBook CreateReviewBook(ReviewBookCreate reviewBookCreate);
    }
}
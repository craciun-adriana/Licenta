﻿using LicentaAPI.AppServices.ReviewBooks.Model;
using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

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
        /// <param name="reviewBookCreate">Details about a reviewBook.</param>
        /// <returns>The created ReviewBook or null if it was not created.</returns>
        public ReviewBook CreateReviewBook(ReviewBookCreate reviewBookCreate);

        public IEnumerable<ReviewBook> GetByStatus(Status status);
    }
}
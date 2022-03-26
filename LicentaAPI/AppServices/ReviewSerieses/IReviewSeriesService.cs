﻿using LicentaAPI.AppServices.ReviewSerieses.Model;
using LicentaAPI.Persistence.Models;

namespace LicentaAPI.AppServices.ReviewSerieses
{   /// <summary>
    /// Interface providing contracts fos <see cref="ReviewSeries"/> related operations.
    /// </summary>
    public interface IReviewSeriesService
    {
        /// <summary>
        /// Create a ReviewSeries.
        /// </summary>
        /// <param name="reviewSeriesCreate">Details about a ReviewSeries.</param>
        /// <returns>The created ReviewSeries or null if it was not created.</returns>
        public ReviewSeries CreateReviewSeries(ReviewSeriesCreate reviewSeriesCreate);
    }
}
using LicentaAPI.AppServices.ReviewSerieses.Model;
using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

namespace LicentaAPI.AppServices.ReviewSerieses
{   /// <summary>
    /// Interface providing contracts for <see cref="ReviewSeries"/> related operations. </summary>
    public interface IReviewSeriesService
    {
        /// <summary>
        /// Create a ReviewSeries.
        /// </summary>
        /// <param name="reviewSeriesCreate">Details about a ReviewSeries.</param>
        /// <returns>The created ReviewSeries or null if it was not created.</returns>
        public ReviewSeries CreateReviewSeries(ReviewSeriesCreate reviewSeriesCreate);

        public IEnumerable<ReviewSeries> GetByStatus(Status status);
    }
}
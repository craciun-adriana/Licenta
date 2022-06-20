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
        public ReviewSeries CreateOrUpdateReviewSeries(ReviewSeriesCreate reviewSeriesCreate);

        public IEnumerable<ReviewSeriesDTO> GetByStatus(Status status, string idUser);

        public IEnumerable<ReviewSeriesDTO> GetReviewSeriesByIdSeries(string idSeries);

        public IEnumerable<ReviewSeriesDTO> GetReviewSeriesCompletedByIdUser(string idUser);

        public ReviewSeries GetReviewSeriesByIdSeriesAndUser(string idSeries, string idUser);
    }
}
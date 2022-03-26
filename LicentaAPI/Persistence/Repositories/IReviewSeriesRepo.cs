using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

namespace LicentaAPI.Persistence.Repositories
{
    /// <summary>
    /// Interface providing contracts for <see cref="ReviewSeries"/>
    /// </summary>
    public interface IReviewSeriesRepo : IGenericRepo<ReviewSeries>
    {
        /// <summary>
        /// Retrieves the ReviewSeries that have the given idSeries.
        /// </summary>
        /// <param name="idSeries">The id of the series that user is searching for.</param>
        /// <returns></returns>
        public IEnumerable<ReviewSeries> FindReviewSeriesByIdSeries(string idSeries);
    }
}
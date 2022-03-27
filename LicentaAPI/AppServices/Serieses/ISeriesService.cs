using LicentaAPI.AppServices.Serieses.Models;
using LicentaAPI.Persistence.Models;

namespace LicentaAPI.AppServices.Serieses
{
    /// <summary>
    /// Interface providing contracts for <see cref="Series"/> related operation.
    /// </summary>
    internal interface ISeriesService
    {
        /// <summary>
        /// Create a series.
        /// </summary>
        /// <param name="seriesCreate">Details about a series.</param>
        /// <returns>The created series or null if it was not created.</returns>
        public Series CreateSeries(SeriesCreate seriesCreate);
    }
}
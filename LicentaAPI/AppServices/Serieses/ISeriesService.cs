using LicentaAPI.AppServices.Serieses.Models;
using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

namespace LicentaAPI.AppServices.Serieses
{
    /// <summary>
    /// Interface providing contracts for <see cref="Series"/> related operation.
    /// </summary>
    public interface ISeriesService
    {
        /// <summary>
        /// Create a series.
        /// </summary>
        /// <param name="seriesCreate">Details about a series.</param>
        /// <returns>The created series or null if it was not created.</returns>
        public Series CreateSeries(SeriesCreate seriesCreate);

        /// <summary>
        /// Gets all series from database.
        /// </summary>
        /// <returns>All series from database.</returns>
        public IEnumerable<Series> GetAllSeries();

        /// <summary>
        /// Returns a series with the given id.
        /// </summary>
        /// <param name="idSeries">The id of the series.</param>
        /// <returns>A series with the given id or null if it was not found.</returns>
        public Series GetSeriesById(string idSeries);

        /// <summary>
        /// Deletes a series with the given id.
        /// </summary>
        /// <param name="idSeries">The id of the series to be deleted.</param>
        public void DeleteSeries(string idSeries);

        /// <summary>
        /// Returns series that have the given string in the title.
        /// </summary>
        /// <param name="title">The title of the series that the user is searching for.</param>
        /// <returns>A list of series that contain the given string in title.</returns>
        public IEnumerable<Series> FindSeriesByTitle(string title);

        /// <summary>
        /// Updates a series.
        /// </summary>
        /// <param name="seriesUpdate">The series that contains the new details.</param>
        /// <returns>The updated series or null if it was not updated and the error.</returns>
        public SeriesUpdateResult UpdateSeries(SeriesUpdate seriesUpdate);
    }
}
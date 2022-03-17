using LicentaAPI.AppServices.Films.Models;
using LicentaAPI.Persistence.Models;

namespace LicentaAPI.AppServices.Films
{
    /// <summary>
    /// Interface providing contracts for <see cref="Film"/> related operations.
    /// </summary>
    public interface IFilmService
    {
        /// <summary>
        /// Create a film.
        /// </summary>
        /// <param name="filmCreate">Details about a film.</param>
        /// <returns>The created film or null if it was not created.</returns>
        public Film CreateFilm(FilmCreate filmCreate);
    }
}
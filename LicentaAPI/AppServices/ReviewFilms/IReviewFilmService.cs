using LicentaAPI.AppServices.ReviewFilms.Model;
using LicentaAPI.Persistence.Models;

namespace LicentaAPI.AppServices.ReviewFilms
{
    /// <summary>
    /// Interface providing contracts for <see cref="ReviewFilm"/> related operations.
    /// </summary>
    public interface IReviewFilmService
    {
        /// <summary>
        /// Create a reviewFilm.
        /// </summary>
        /// <param name="reviewFilmCreate">Details about a reviewFilm.</param>
        /// <returns>The created ReviewFilm or null if it was not created.</returns>
        public ReviewFilm CreateReviewFilm(ReviewFilmCreate reviewFilmCreate);
    }
}
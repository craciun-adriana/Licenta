using LicentaAPI.AppServices.ReviewFilms.Model;
using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

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
        public ReviewFilm CreateOrUpdateReviewFilm(ReviewFilmCreate reviewFilmCreate);

        public IEnumerable<ReviewFilmDTO> GetByStatus(Status status, string idUser);

        public IEnumerable<ReviewFilm> GetReviewFilmByIdFilm(string idFilm);

        public IEnumerable<ReviewFilmDTO> GetReviewFilmCompletedByIdUser(string idUser);

        public ReviewFilm GetReviewFilmByIdFilmAndUser(string idFilm, string idUser);
    }
}
using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

namespace LicentaAPI.Persistence.Repositories
{
    /// <summary>
    ///Interface providing contracts for <see cref="ReviewFilm"/>
    /// </summary>
    public interface IReviewFilmRepo : IGenericRepo<ReviewFilm>
    {
        /// <summary>
        ///Retrieves the ReviewFilm that have the given idFilm.
        /// </summary>
        /// <param name="idFilm">The id of the film that user is searching for.</param>
        /// <returns>All reviews received by a film with given idFilm.</returns>
        public IEnumerable<ReviewFilm> FindReviewFilmByIdFilm(string idFilm);

        public IEnumerable<ReviewFilm> GetByStatus(Status status);

        public IEnumerable<ReviewFilm> GetReviewFilmCompletedByIdUser(string idUser);

        public ReviewFilm GetReviewFilmByIdFilmAndUser(string idFilm, string idUser);
    }
}
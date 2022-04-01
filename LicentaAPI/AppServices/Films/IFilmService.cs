using LicentaAPI.AppServices.Films.Models;
using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

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

        /// <summary>
        /// Gets all films from database.
        /// </summary>
        /// <returns>All books from database.</returns>
        public IEnumerable<Film> GetAllFilms();

        /// <summary>
        /// Returns a film with the given id.
        /// </summary>
        /// <param name="idFilm">The id of the film.</param>
        /// <returns>A film with the given id or null if it was not found.</returns>
        public Film GetFilmById(string idFilm);

        /// <summary>
        /// Deletes a film with the given id.
        /// </summary>
        /// <param name="idFilm">The id of the film to be deleted.</param>
        public void DeleteBook(string idFilm);

        /// <summary>
        /// Returns films that have the given string in the title.
        /// </summary>
        /// <param name="title">The title of the film that the user is searching for.</param>
        /// <returns>A list of films that contain the given string in title.</returns>
        public IEnumerable<Film> FindFilmByTitle(string title);

        /// <summary>
        /// Updates a film.
        /// </summary>
        /// <param name="filmUpdate">The film that contains the new details.</param>
        /// <returns>The updated film or null if it was not updated and the error.</returns>
        public FilmUpdateResult UpdateFilm(FilmUpdate filmUpdate);
    }
}
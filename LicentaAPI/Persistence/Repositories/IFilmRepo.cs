using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

namespace LicentaAPI.Persistence.Repositories
{
    /// <summary>
    /// Interface providing contracts for <see cref="Film"/> repository.
    /// </summary>
    public interface IFilmRepo : IGenericRepo<Film>
    {
        /// <summary>
        /// Retrieves films that have the given title.
        /// </summary>
        /// <param name="title">The title of the film that the user is searching for.</param>
        /// <returns>A list of films that contain the given string in title.</returns>
        public IEnumerable<Film> FindFilmByTitle(string title);

        /// <summary>
        /// Retrieves films that have the given genre.
        /// </summary>
        /// <param name="genre">The title of the film that the user is searching for.</param>
        /// <returns>A list of films that contain the given string in title.</returns>
        public IEnumerable<Film> FindFilmByGenre(Genre genre);
    }
}
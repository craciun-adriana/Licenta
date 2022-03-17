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
        /// <returns></returns>
        public IEnumerable<Film> FindFilmByTitle(string title);
    }
}
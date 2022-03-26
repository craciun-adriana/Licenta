﻿using LicentaAPI.Persistence.Models;
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
        /// <returns></returns>
        public IEnumerable<ReviewFilm> FindReviewFilmByIdFilm(string idFilm);
    }
}
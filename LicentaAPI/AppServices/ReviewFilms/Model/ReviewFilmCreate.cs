using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.AppServices.ReviewFilms.Model
{
    /// <summary>
    ///Class containing information needed to create a <see cref="ReviewFilm"/>
    /// </summary>
    public class ReviewFilmCreate
    {
        public string IdUser { get; set; }

        public string IdFilm { get; set; }

        public int Grade { get; set; }

        public string Review { get; set; }

        public Status Status { get; set; }
    }
}
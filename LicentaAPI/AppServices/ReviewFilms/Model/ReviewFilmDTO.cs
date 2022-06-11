using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.AppServices.ReviewFilms.Model
{
    public class ReviewFilmDTO
    {
        public string IdReview { get; set; }

        public string IdUser { get; set; }

        public string IdFilm { get; set; }

        public int? Grade { get; set; }

        public string Review { get; set; }

        public Status Status { get; set; }

        public Film Film { get; set; }
    }
}
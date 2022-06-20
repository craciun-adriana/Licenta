using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.AppServices.ReviewSerieses.Model
{
    public class ReviewSeriesDTO
    {
        public string IdReview { get; set; }

        public string IdUser { get; set; }

        public string Username { get; set; }

        public string IdSeries { get; set; }

        public int? Grade { get; set; }

        public string Review { get; set; }

        public Status Status { get; set; }

        public Series Series { get; set; }
    }
}
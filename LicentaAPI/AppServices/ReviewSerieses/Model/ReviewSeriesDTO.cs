﻿using LicentaAPI.Persistence.Models;
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

        public string IdSeries { get; set; }

        public int? Grade { get; set; }

        public string Review { get; set; }

        public Status Status { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public string Description { get; set; }

        public DateTime RelaseDate { get; set; }

        public string PrequelID { get; set; }

        public string SequelID { get; set; }

        public Genre Genre { get; set; }

        public Rating Rating { get; set; }

        public int NrEps { get; set; }

        public string Picture { get; set; }
    }
}
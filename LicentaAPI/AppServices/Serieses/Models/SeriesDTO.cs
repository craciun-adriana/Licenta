using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.AppServices.Serieses.Models
{
    public class SeriesDTO
    {
        public string ID { get; set; }
        public string Title { get; set; }

        public string Director { get; set; }

        public string Description { get; set; }

        public DateTime RelaseDate { get; set; }

        public string PrequelID { get; set; }

        public string PrequelTitle { get; set; }

        public string SequelID { get; set; }

        public string SequelTitle { get; set; }

        public Genre Genre { get; set; }

        public Rating Rating { get; set; }

        public int NrEps { get; set; }

        public string Picture { get; set; }
    }
}
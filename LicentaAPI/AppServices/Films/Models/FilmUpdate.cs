using LicentaAPI.Persistence.Models;
using System;

namespace LicentaAPI.AppServices.Films.Models
{
    public class FilmUpdate
    {
        public string ID { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public string Description { get; set; }

        public DateTime RelaseDate { get; set; }

        public string PrequelID { get; set; }

        public string SequelID { get; set; }

        public Genre Genre { get; set; }

        public Rating Rating { get; set; }

        public int Length { get; set; }

        public string Picture { get; set; }
    }
}
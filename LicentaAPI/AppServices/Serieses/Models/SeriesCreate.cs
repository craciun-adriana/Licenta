using LicentaAPI.Persistence.Models;
using System;

namespace LicentaAPI.AppServices.Serieses.Models
{
    /// <summary>
    /// Class containing information needed to create a <see cref="Series"/>
    /// </summary>
    public class SeriesCreate
    {
        public string Title { get; set; }

        public string Director { get; set; }

        public string Description { get; set; }

        public DateTime RelaseDate { get; set; }

        public string PrequelID { get; set; }

        public string SequelID { get; set; }

        public Genre Genre { get; set; }

        public Rating Rating { get; set; }

        public int NrEps { get; set; }
    }
}
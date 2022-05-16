using System;
using System.ComponentModel.DataAnnotations;

namespace LicentaUI.Models
{
    public class SeriesModel
    {
        public string ID { get; set; }

        [Display(Name = "Series Titles")]
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
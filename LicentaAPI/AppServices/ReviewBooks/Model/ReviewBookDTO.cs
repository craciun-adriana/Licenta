using LicentaAPI.Persistence.Models;
using System;

namespace LicentaAPI.AppServices.ReviewBooks.Model
{
    public class ReviewBookDTO
    {
        public string IdReview { get; set; }

        public string IdUser { get; set; }

        public string IdBook { get; set; }

        public int? Grade { get; set; }

        public string Review { get; set; }

        public Status Status { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public DateTime RelaseDate { get; set; }

        public string PrequelID { get; set; }

        public string SequelID { get; set; }

        public Genre Genre { get; set; }

        public string Picture { get; set; }
    }
}
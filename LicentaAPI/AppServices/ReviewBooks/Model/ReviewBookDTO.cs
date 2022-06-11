using LicentaAPI.Persistence.Models;
using System;

namespace LicentaAPI.AppServices.ReviewBooks.Model
{
    public class ReviewBookDTO
    {
        public string IdReview { get; set; }

        public string IdUser { get; set; }

        public string Username { get; set; }

        public string IdBook { get; set; }

        public int? Grade { get; set; }

        public string Review { get; set; }

        public Status Status { get; set; }

        public Book Book { get; set; }
    }
}
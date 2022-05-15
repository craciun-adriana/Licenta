namespace LicentaUI.Models
{
    public class ReviewFilmModel
    {
        public string ID { get; set; }

        public string IdUser { get; set; }

        public string IdFilm { get; set; }

        public int? Grade { get; set; }

        public string Review { get; set; }

        public Status Status { get; set; }
    }
}
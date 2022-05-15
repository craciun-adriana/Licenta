namespace LicentaUI.Models
{
    public class ReviewSeriesModel
    {
        public string ID { get; set; }

        public string IdUser { get; set; }

        public string IdSeries { get; set; }

        public int? Grade { get; set; }

        public string Review { get; set; }

        public Status Status { get; set; }
    }
}
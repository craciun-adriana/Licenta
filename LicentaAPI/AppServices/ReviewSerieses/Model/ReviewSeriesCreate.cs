using LicentaAPI.Persistence.Models;

namespace LicentaAPI.AppServices.ReviewSerieses.Model
{
    public class ReviewSeriesCreate
    {
        public string IdUser { get; set; }

        public string IdSeries { get; set; }

        public int Grade { get; set; }

        public string Review { get; set; }

        public Status Status { get; set; }
    }
}
using LicentaAPI.Persistence.Models;

namespace LicentaAPI.AppServices.Serieses.Models
{
    public class SeriesUpdateResult
    {
        public string Error { get; set; }

        public Series UpdatedSeries { get; set; }
    }
}
using LicentaAPI.Persistence.Models;

namespace LicentaAPI.AppServices.Films.Models
{
    public class FilmUpdateResult
    {
        public Film FilmUpdate { get; set; }
        public string Error;
    }
}
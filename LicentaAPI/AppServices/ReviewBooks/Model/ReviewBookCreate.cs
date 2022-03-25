using LicentaAPI.Persistence.Models;

namespace LicentaAPI.AppServices.ReviewBooks.Model
{
    /// <summary>
    /// Class containing information needed to create a <see cref="ReviewBook"/>.
    /// </summary>
    public class ReviewBookCreate
    {
        public string IdUser { get; set; }

        public string IdBook { get; set; }

        public int Grade { get; set; }

        public string Review { get; set; }

        public Status Status { get; set; }
    }
}
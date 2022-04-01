using LicentaAPI.Persistence.Models;

namespace LicentaAPI.AppServices.Books.Models
{
    public class BookUpdateResult
    {
        public Book UpdatedBook { get; set; }

        public string Error { get; set; }
    }
}
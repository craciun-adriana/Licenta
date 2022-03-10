using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicentaAPI.Persistence.Models
{
    public class ReviewFilm
    {
        [Key]
        public string ID { get; set; }

        [Required]
        [ForeignKey(nameof(AppUser))]
        public string IdUser { get; set; }

        [Required]
        [ForeignKey(nameof(Film))]
        public string IdFilm { get; set; }

        public int Grade { get; set; }

        public string Review { get; set; }

        public Status Status { get; set; }
    }
}
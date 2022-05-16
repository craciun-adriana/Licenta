using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicentaAPI.Persistence.Models
{
    /// <summary>
    /// This class holds information about a film.
    /// </summary>
    public class Film
    {
        [Key]
        public string ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime RelaseDate { get; set; }

        [ForeignKey(nameof(Film))]
        public string PrequelID { get; set; }

        [ForeignKey(nameof(Film))]
        public string SequelID { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        public Rating Rating { get; set; }

        [Required]
        public int Length { get; set; }

        [Required]
        public string Picture { get; set; }
    }
}
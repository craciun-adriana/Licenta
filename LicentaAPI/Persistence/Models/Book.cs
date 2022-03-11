using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicentaAPI.Persistence.Models
{
    /// <summary>
    ///This class holds information about a book.
    /// </summary>
    public class Book
    {
        [Key]
        public string ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime RelaseDate { get; set; }

        [ForeignKey(nameof(Book))]
        public string PrequelID { get; set; }

        [ForeignKey(nameof(Book))]
        public string SequelID { get; set; }

        [Required]
        public Genre Genre { get; set; }
    }
}
using LicentaAPI.Persistence.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace LicentaAPI.Controllers.Models
{
    public class BookCreateRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime RelaseDate { get; set; }

        public string PrequelID { get; set; }

        public string SequelID { get; set; }

        [Required]
        public Genre Genre { get; set; }
    }
}
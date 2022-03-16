using LicentaAPI.Persistence.Models;
using System;

namespace LicentaAPI.AppServices.Books.Models
{
    /// <summary>
    /// Class containing information needed to create a <see cref="Book"/>.
    /// </summary>
    public class BookCreate
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public DateTime RelaseDate { get; set; }

        public string PrequelID { get; set; }

        public string SequelID { get; set; }

        public Genre Genre { get; set; }
    }
}
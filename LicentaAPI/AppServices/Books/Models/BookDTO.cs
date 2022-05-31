using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.AppServices.Books.Models
{
    public class BookDTO
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public DateTime RelaseDate { get; set; }

        public string PrequelID { get; set; }

        public string PrequelTitle { get; set; }

        public string SequelID { get; set; }

        public string SequelTitle { get; set; }

        public Genre Genre { get; set; }

        public string Picture { get; set; }
    }
}
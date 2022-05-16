using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaUI.Models
{
    public class BookModel
    {
        public string ID { get; set; }

        [Display(Name = "Book Titles")]
        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public DateTime RelaseDate { get; set; }

        public string PrequelID { get; set; }

        public string SequelID { get; set; }

        public Genre Genre { get; set; }

        public string Picture { get; set; }
    }
}
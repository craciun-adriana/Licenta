using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicentaAPI.Persistence.Models
{
    public class Appointment
    {
        [Key]
        public string ID { get; set; }

        [Required]
        public DateTime TimeAppointment { get; set; }

        [ForeignKey(nameof(Book))]
        public string IdBook { get; set; }

        [ForeignKey(nameof(Film))]
        public string IdFilm { get; set; }

        [ForeignKey(nameof(Series))]
        public string IdSeries { get; set; }

        [Required]
        [ForeignKey(nameof(Group))]
        public string IdGroup { get; set; }

        public string Location { get; set; }
    }
}
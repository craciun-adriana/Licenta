using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicentaAPI.Persistence.Models
{
    /// <summary>
    /// This class holds details about an appointment created by a <see cref="Group"/>.
    /// </summary>
    public class Appointment
    {
        [Key]
        public string ID { get; set; }

        /// <summary>
        /// This attribute represents the time and date when the appointment is set.
        /// </summary>
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
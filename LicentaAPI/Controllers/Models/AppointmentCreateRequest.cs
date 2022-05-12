using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.Controllers.Models
{
    public class AppointmentCreateRequest
    {
        public string Name { get; set; }

        /// <summary>
        /// This attribute represents the time and date when the appointment is set.
        /// </summary>
        [Required]
        public DateTime TimeAppointment { get; set; }

        public string IdBook { get; set; }

        public string IdFilm { get; set; }

        public string IdSeries { get; set; }

        [Required]
        public string IdGroup { get; set; }

        public string Location { get; set; }
    }
}
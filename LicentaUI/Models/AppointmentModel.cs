using System;

namespace LicentaUI.Models
{
    public class AppointmentModel
    {
        public string ID { get; set; }

        public DateTime TimeAppointment { get; set; }

        public string IdBook { get; set; }

        public string IdFilm { get; set; }

        public string IdSeries { get; set; }

        public string IdGroup { get; set; }

        public string Location { get; set; }
    }
}
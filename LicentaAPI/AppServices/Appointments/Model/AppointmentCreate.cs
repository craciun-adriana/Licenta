using System;

namespace LicentaAPI.AppServices.Appointments.Model
{
    /// <summary>
    /// Class contains information needed to create a <see cref="Appointment"/>
    /// </summary>
    public class AppointmentCreate
    {
        public string Name { get; set; }

        public DateTime TimeAppointment { get; set; }

        public string IdBook { get; set; }

        public string IdFilm { get; set; }

        public string IdSeries { get; set; }

        public string IdGroup { get; set; }

        public string Location { get; set; }
    }
}
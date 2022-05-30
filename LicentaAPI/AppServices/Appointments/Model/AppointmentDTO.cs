using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.AppServices.Appointments.Model
{
    public class AppointmentDTO
    {
        public string IdAppointment { get; set; }

        public string Name { get; set; }

        public DateTime TimeAppointment { get; set; }

        public string IdBook { get; set; }

        public string TitleBook { get; set; }

        public string IdFilm { get; set; }

        public string TitleFilm { get; set; }

        public string IdSeries { get; set; }

        public string TitleSeries { get; set; }

        public string IdGroup { get; set; }

        public string GroupName { get; set; }

        public string Location { get; set; }
    }
}
﻿using System;

namespace LicentaUI.Models
{
    public class AppointmentModel
    {
        public string IdAppointment { get; set; }

        public string Name { get; set; }

        public DateTime TimeAppointment { get; set; }

        public string IdBook { get; set; }

        public string TitleBook { get; set; }

        public string TitleFilm { get; set; }

        public string TitleSeries { get; set; }

        public string IdFilm { get; set; }

        public string IdSeries { get; set; }

        public string IdGroup { get; set; }

        public string Location { get; set; }
    }
}
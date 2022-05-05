using LicentaAPI.AppServices.Appointments.Model;
using LicentaAPI.Persistence.Models;
using System.Collections.Generic;

namespace LicentaAPI.AppServices.Appointments
{
    /// <summary>
    /// Interface providing contracts for <see cref="Appointment"/> related operations.
    /// </summary>
    public interface IAppointmentService
    {
        /// <summary>
        /// Create an appointment.
        /// </summary>
        /// <param name="appointmentCreate"></param>
        /// <returns>The created appointment or null if it was not created.</returns>
        public Appointment CreateAppointment(AppointmentCreate appointmentCreate);

        /// <summary>
        /// </summary>
        /// <param name="idMember"></param>
        /// <returns></returns>
        public IEnumerable<Appointment> GetAllAppointmentsForUser(string idMember);
    }
}
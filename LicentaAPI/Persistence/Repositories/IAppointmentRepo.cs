using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;

namespace LicentaAPI.Persistence.Repositories
{
    /// <summary>
    /// Interface providing contracts for <see cref="Appointment"/> repository.
    /// </summary>
    public interface IAppointmentRepo : IGenericRepo<Appointment>
    {
        /// <summary>
        /// Retrieves the appointments that have the given date.
        /// </summary>
        /// <param name="date">The date of the appointment that the user is searching for.</param>
        /// <returns></returns>
        public IEnumerable<Appointment> FindAppointmentByDate(DateTime date);

        /// <summary>
        /// Retrieves all appointments that a certain group have.
        /// </summary>
        /// <param name="idGroup">The group id we are locking for appointments.</param>
        /// <returns>All appointments that given group have.</returns>
        public IEnumerable<Appointment> FindAppointmentByGroupId(string idGroup);
    }
}
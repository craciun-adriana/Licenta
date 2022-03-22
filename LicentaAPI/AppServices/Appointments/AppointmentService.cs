using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Repositories;
using LicentaAPI.Persistence.Models;
using LicentaAPI.AppServices.Appointments.Model;
using System;

namespace LicentaAPI.AppServices.Appointments
{
    /// <summary>
    /// Concrete implementation of <see cref="IAppointmentService"/>.
    /// </summary>
    public class AppointmentService : IAppointmentService
    {
        private IAppointmentRepo _appointmentRepo;
        private IMappingCoordinator _mapper;

        public AppointmentService(IAppointmentRepo appointmentRepo, IMappingCoordinator mapper)
        {
            _appointmentRepo = appointmentRepo;
            _mapper = mapper;
        }

        ///<inheritdoc/>
        public Appointment CreateAppointment(AppointmentCreate appointmentCreate)
        {
            var appointment = _mapper.Map<AppointmentCreate, Appointment>(appointmentCreate);
            try
            {
                _appointmentRepo.Add(appointment);
            }
            catch (ArgumentNullException)
            {
                return null;
            }

            return appointment;
        }
    }
}
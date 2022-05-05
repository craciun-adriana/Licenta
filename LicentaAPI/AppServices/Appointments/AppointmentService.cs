using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Repositories;
using LicentaAPI.Persistence.Models;
using LicentaAPI.AppServices.Appointments.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LicentaAPI.AppServices.Appointments
{
    /// <summary>
    /// Concrete implementation of <see cref="IAppointmentService"/>.
    /// </summary>
    public class AppointmentService : IAppointmentService
    {
        private IAppointmentRepo _appointmentRepo;
        private IGroupRepo _groupRepo;
        private IMappingCoordinator _mapper;

        public AppointmentService(IAppointmentRepo appointmentRepo, IGroupRepo groupRepo, IMappingCoordinator mapper)
        {
            _appointmentRepo = appointmentRepo;
            _groupRepo = groupRepo;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public Appointment CreateAppointment(AppointmentCreate appointmentCreate)
        {
            var appointment = _mapper.Map<AppointmentCreate, Appointment>(appointmentCreate);
            appointment.ID = Guid.NewGuid().ToString();
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

        public IEnumerable<Appointment> GetAllAppointmentsForUser(string idMember)
        {
            var groups = _groupRepo.FindGroupsByMemberId(idMember).ToList();
            var appointmentList = new List<Appointment>();
            foreach (var group in groups)
            {
                appointmentList.AddRange(_appointmentRepo.FindAppointmentByGroupId(group.ID));
            }
            return appointmentList;
        }

        //get all app
    }
}
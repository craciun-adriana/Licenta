using LicentaAPI.AppServices.Appointments.Model;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
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
        private readonly IAppointmentRepo _appointmentRepo;
        private readonly IGroupRepo _groupRepo;
        private readonly IBookRepo _bookRepo;
        private readonly IFilmRepo _filmRepo;
        private readonly ISeriesRepo _seriesRepo;
        private readonly IMappingCoordinator _mapper;

        public AppointmentService(
            IAppointmentRepo appointmentRepo,
            IBookRepo bookRepo,
            IFilmRepo filmRepo,
            ISeriesRepo seriesRepo,
            IGroupRepo groupRepo,
            IMappingCoordinator mapper)
        {
            _appointmentRepo = appointmentRepo;
            _groupRepo = groupRepo;
            _bookRepo = bookRepo;
            _filmRepo = filmRepo;
            _seriesRepo = seriesRepo;
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

        public IEnumerable<AppointmentDTO> GetAllAppointmentsForUser(string idMember)
        {
            var groups = _groupRepo.FindGroupsByMemberId(idMember).ToList();
            var appointmentList = new List<AppointmentDTO>();
            foreach (var group in groups)
            {
                _appointmentRepo.FindAppointmentByGroupId(group.ID)
                    .Where(a => a.TimeAppointment.CompareTo(DateTime.Now) > 0)
                    .ToList()
                    .ForEach(a =>
                    {
                        var appointmentDto = new AppointmentDTO
                        {
                            IdAppointment = a.ID,
                            IdBook = a.IdBook,
                            IdFilm = a.IdFilm,
                            IdSeries = a.IdSeries,
                            IdGroup = a.IdGroup,
                            Location = a.Location,
                            Name = a.Name,
                            TimeAppointment = a.TimeAppointment,
                        };

                        if (!string.IsNullOrEmpty(a.IdFilm))
                        {
                            appointmentDto.TitleFilm = _filmRepo.GetById(a.IdFilm).Title;
                        }
                        if (!string.IsNullOrEmpty(a.IdBook))
                        {
                            appointmentDto.TitleBook = _bookRepo.GetById(a.IdBook).Title;
                        }
                        if (!string.IsNullOrEmpty(a.IdSeries))
                        {
                            appointmentDto.TitleSeries = _seriesRepo.GetById(a.IdSeries).Title;
                        }
                        appointmentDto.GroupName = _groupRepo.GetById(group.ID).Name;
                        appointmentList.Add(appointmentDto);
                    });
            }
            return appointmentList;
        }
    }
}
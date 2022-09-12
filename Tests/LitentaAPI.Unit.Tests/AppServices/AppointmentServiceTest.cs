using LicentaAPI.AppServices.Appointments;
using LicentaAPI.AppServices.Appointments.Model;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LitentaAPI.Unit.Tests.AppServices
{
    public class AppointmentServiceTest
    {
        private AppointmentService service;
        private Mock<IAppointmentRepo> appointmentRepo;

        public AppointmentServiceTest()
        {
            appointmentRepo = new Mock<IAppointmentRepo>();
            service = new AppointmentService(appointmentRepo.Object, null, null, null, null, new MappingCoordinator());
        }

        [Fact]
        public void CreateAppointmentWithCorrectData_AppointmentIsCreated()
        {
            var appointmentCreate = new AppointmentCreate()
            {
                IdBook = "idBook",
                Location = "location",
                Name = "name",
                TimeAppointment = DateTime.UtcNow,
                IdGroup = "idGroup"
            };
            appointmentRepo.Setup(x => x.Add(It.IsAny<Appointment>())).Verifiable();
            appointmentRepo.Setup(x => x.FindAppointmentByDate(DateTime.UtcNow)).Returns(Enumerable.Empty<Appointment>());
            appointmentRepo.Setup(x => x.FindAppointmentByDate(DateTime.UtcNow.AddDays(1))).Returns(Enumerable.Empty<Appointment>());

            var createdAppointment = service.CreateAppointment(appointmentCreate);

            Assert.NotEmpty(createdAppointment.ID);
            Assert.Equal(appointmentCreate.IdBook, createdAppointment.IdBook);
            Assert.True(string.IsNullOrEmpty(createdAppointment.IdFilm));
            Assert.True(string.IsNullOrEmpty(createdAppointment.IdSeries));
            Assert.Equal(appointmentCreate.Location, createdAppointment.Location);
            Assert.Equal(appointmentCreate.IdGroup, createdAppointment.IdGroup);
            Assert.Equal(appointmentCreate.Name, createdAppointment.Name);
            Assert.Equal(appointmentCreate.TimeAppointment, createdAppointment.TimeAppointment);
            appointmentRepo.Verify(x => x.Add(createdAppointment), Times.Once);
        }

        [Fact]
        public void CreateAppointmentWithNull_AppointmentIsNotCreated()
        {
            var createdAppointment = service.CreateAppointment(null);

            Assert.Null(createdAppointment);
        }
    }
}
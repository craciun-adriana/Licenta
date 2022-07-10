using LicentaAPI.AppServices.Appointments;
using LicentaAPI.AppServices.Appointments.Model;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Repositories;
using LitentaAPI.Unit.Tests.Fakes.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LitentaAPI.Unit.Tests.AppServices
{
    public class AppointmentServiceTest
    {
        private AppointmentService service;
        private IAppointmentRepo appointmentRepo;

        public AppointmentServiceTest()
        {
            appointmentRepo = new FakeAppointmentRepo();
            service = new AppointmentService(appointmentRepo, null, null, null, null, new MappingCoordinator());
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

            var createdAppointment = service.CreateAppointment(appointmentCreate);

            Assert.NotEmpty(createdAppointment.ID);
            Assert.Equal(appointmentCreate.IdBook, createdAppointment.IdBook);
            Assert.True(string.IsNullOrEmpty(createdAppointment.IdFilm));
            Assert.True(string.IsNullOrEmpty(createdAppointment.IdSeries));
            Assert.Equal(appointmentCreate.Location, createdAppointment.Location);
            Assert.Equal(appointmentCreate.IdGroup, createdAppointment.IdGroup);
            Assert.Equal(appointmentCreate.Name, createdAppointment.Name);
            Assert.Equal(appointmentCreate.TimeAppointment, createdAppointment.TimeAppointment);
        }

        [Fact]
        public void CreateAppointmentWithNull_AppointmentIsNotCreated()
        {
            var createdAppointment = service.CreateAppointment(null);

            Assert.Null(createdAppointment);
        }
    }
}
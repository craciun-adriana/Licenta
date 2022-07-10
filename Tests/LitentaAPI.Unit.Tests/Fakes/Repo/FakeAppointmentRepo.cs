using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LitentaAPI.Unit.Tests.Fakes.Repo
{
    public class FakeAppointmentRepo : IAppointmentRepo
    {
        private List<Appointment> _appointments;

        public FakeAppointmentRepo()
        {
            _appointments = new List<Appointment>();
        }

        public void Add(Appointment entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _appointments.Add(entity);
        }

        public void Delete(Appointment entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _appointments.Remove(entity);
        }

        public IEnumerable<Appointment> Filter(PaginationQuery paginationQuery)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> FindAppointmentByDate(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                throw new ArgumentNullException(nameof(date));
            }
            return _appointments.Where(appointment => appointment.TimeAppointment.Equals(date));
        }

        public IEnumerable<Appointment> FindAppointmentByGroupId(string idGroup)
        {
            if (idGroup == null)
            {
                throw new ArgumentNullException(nameof(idGroup));
            }
            return _appointments.Where(appointment => appointment.IdGroup.Equals(idGroup));
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointments.ToList();
        }

        public Appointment GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            return _appointments.FirstOrDefault(appointment => appointment.ID.Equals(id));
        }

        public void Update(Appointment entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            var old = GetById(entity.ID);
            Delete(old);
            Add(entity);
        }
    }
}
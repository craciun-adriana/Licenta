using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LicentaAPI.Persistence.Repositories
{
    /// <summary>
    /// Concrete implementation of <see cref="Appointment"/> using Entity Framework.
    /// </summary>
    public class EFAppointmentRepository : IAppointmentRepo
    {
        private AppDbContext _dbContext;

        public EFAppointmentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public void Add(Appointment entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbContext.Appointments.Add(entity);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(Appointment entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbContext.Appointments.Remove(entity);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public IEnumerable<Appointment> FindAppointmentByDate(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                throw new ArgumentNullException(nameof(date));
            }
            return _dbContext.Appointments.Where(appointment => appointment.TimeAppointment.Equals(date));
        }

        /// <inheritdoc/>
        public IEnumerable<Appointment> GetAll()
        {
            return _dbContext.Appointments.ToList();
        }

        /// <inheritdoc/>
        public Appointment GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            return _dbContext.Appointments.FirstOrDefault(appointment => appointment.ID.Equals(id));
        }

        /// <inheritdoc/>
        public IEnumerable<Appointment> Filter(PaginationQuery paginationQuery)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Update(Appointment entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbContext.Appointments.Update(entity);
        }
    }
}
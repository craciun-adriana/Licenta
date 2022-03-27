using LicentaAPI.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.Persistence.Repositories
{
    /// <summary>
    /// Interface providing contracts for <see cref="Series"/> repository.
    /// </summary>
    public interface ISeriesRepo : IGenericRepo<Series>
    {
        /// <summary>
        /// Retrieves series that have the given title.
        /// </summary>
        /// <param name="title">The title of the series that the user is searching for.</param>
        /// <returns></returns>
        public IEnumerable<Series> FindSeriesByTitle(string title);
    }
}
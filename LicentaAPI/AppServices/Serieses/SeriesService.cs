using LicentaAPI.AppServices.Serieses.Models;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using System;

namespace LicentaAPI.AppServices.Serieses
{
    /// <summary>
    /// Concrete implementation of <see cref="ISeriesService"/>
    /// </summary>
    public class SeriesService : ISeriesService
    {
        private ISeriesRepo _seriesRepo;
        private IMappingCoordinator _mapper;

        public SeriesService(ISeriesRepo seriesRepo, IMappingCoordinator mapper)
        {
            _seriesRepo = seriesRepo;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public Series CreateSeries(SeriesCreate seriesCreate)
        {
            var series = _mapper.Map<SeriesCreate, Series>(seriesCreate);
            try
            {
                _seriesRepo.Add(series);
            }
            catch (ArgumentNullException)
            {
                return null;
            }

            return series;
        }
    }
}
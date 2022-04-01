using LicentaAPI.AppServices.Serieses.Models;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;

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
            series.ID = Guid.NewGuid().ToString();
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

        ///<inheritdoc/>
        public void DeleteSeries(string idSeries)
        {
            var series = GetSeriesById(idSeries);

            if (series != null)
            {
                _seriesRepo.Delete(series);
            }
        }

        ///<inheritdoc/>
        public IEnumerable<Series> FindSeriesByTitle(string title)
        {
            return _seriesRepo.FindSeriesByTitle(title);
        }

        ///<inheritdoc/>
        public Series GetSeriesById(string idSeries)
        {
            return _seriesRepo.GetById(idSeries);
        }

        ///<inheritdoc/>
        public SeriesUpdateResult UpdateSeries(SeriesUpdate seriesUpdate)
        {
            var series = GetSeriesById(seriesUpdate.ID);
            if (series == null)
            {
                return new SeriesUpdateResult
                {
                    Error = "Series not found.",
                    UpdatedSeries = null
                };
            }

            _mapper.Map(seriesUpdate, series);
            _seriesRepo.Update(series);

            return new SeriesUpdateResult
            {
                Error = "",
                UpdatedSeries = series
            };
        }
    }
}
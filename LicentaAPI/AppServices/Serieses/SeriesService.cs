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
            var seriesDTO = GetSeriesById(idSeries);
            var series = _mapper.Map<SeriesDTO, Series>(seriesDTO);

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

        public IEnumerable<Series> GetAllSeries()
        {
            return _seriesRepo.GetAll();
        }

        ///<inheritdoc/>
        public SeriesDTO GetSeriesById(string idSeries)
        {
            var series = _seriesRepo.GetById(idSeries);
            var seriesDTO = _mapper.Map<Series, SeriesDTO>(series);

            if (string.IsNullOrEmpty(seriesDTO.PrequelID))
            {
                seriesDTO.PrequelTitle = _seriesRepo.GetById(series.PrequelID).Title;
            }

            if (string.IsNullOrEmpty(seriesDTO.SequelID))
            {
                seriesDTO.SequelTitle = _seriesRepo.GetById(series.SequelID).Title;
            }

            return seriesDTO;
        }

        ///<inheritdoc/>
        public SeriesUpdateResult UpdateSeries(SeriesUpdate seriesUpdate)
        {
            var seriesDTO = GetSeriesById(seriesUpdate.ID);
            var series = _mapper.Map<SeriesDTO, Series>(seriesDTO);

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
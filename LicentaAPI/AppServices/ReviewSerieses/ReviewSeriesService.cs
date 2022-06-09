using LicentaAPI.AppServices.ReviewSerieses.Model;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LicentaAPI.AppServices.ReviewSerieses
{
    /// <summary>
    /// Concrete implementation of <see cref="IReviewSeriesService"/>.
    /// </summary>
    public class ReviewSeriesService : IReviewSeriesService
    {
        private readonly IReviewSeriesRepo _reviewSeriesRepo;
        private readonly ISeriesRepo _seriesRepo;
        private readonly IMappingCoordinator _mapper;

        public ReviewSeriesService(IReviewSeriesRepo reviewSeriesRepo, ISeriesRepo seriesRepo, IMappingCoordinator mapper)
        {
            _reviewSeriesRepo = reviewSeriesRepo;
            _seriesRepo = seriesRepo;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public ReviewSeries CreateReviewSeries(ReviewSeriesCreate reviewSeriesCreate)
        {
            var reviewSeries = _mapper.Map<ReviewSeriesCreate, ReviewSeries>(reviewSeriesCreate);
            reviewSeries.ID = Guid.NewGuid().ToString();
            try
            {
                _reviewSeriesRepo.Add(reviewSeries);
            }
            catch (ArgumentNullException)
            {
                return null;
            }

            return reviewSeries;
        }

        public IEnumerable<ReviewSeriesDTO> GetByStatus(Status status, string idUser)
        {
            return _reviewSeriesRepo.GetByStatus(status, idUser)
                 .Select(rb =>
                 {
                     var series = _seriesRepo.GetById(rb.IdSeries);
                     return new ReviewSeriesDTO
                     {
                         IdSeries = rb.IdSeries,
                         Director = series.Director,
                         Description = series.Description,
                         Genre = series.Genre,
                         Grade = rb.Grade,
                         IdReview = rb.ID,
                         IdUser = rb.IdUser,
                         PrequelID = series.PrequelID,
                         RelaseDate = series.RelaseDate,
                         Review = rb.Review,
                         SequelID = series.SequelID,
                         Status = rb.Status,
                         Title = series.Title,
                         Rating = series.Rating,
                         NrEps = series.NrEps,
                         Picture = series.Picture
                     };
                 });
        }

        public IEnumerable<ReviewSeries> GetReviewSeriesByIdSeries(string idSeries)
        {
            return _reviewSeriesRepo.FindReviewSeriesByIdSeries(idSeries);
        }

        public ReviewSeries GetReviewSeriesByIdSeriesAndUser(string idSeries, string idUser)
        {
            return _reviewSeriesRepo.GetReviewSeriesByIdSeriesAndUser(idSeries, idUser);
        }

        public IEnumerable<ReviewSeriesDTO> GetReviewSeriesCompletedByIdUser(string idUser)
        {
            var revSeries = _reviewSeriesRepo.GetReviewSeriesCompletedByIdUser(idUser);
            var revBookDTO = _mapper.Map<ReviewSeries, ReviewSeriesDTO>(revSeries);
            foreach (var item in revBookDTO)
            {
                item.Title = _seriesRepo.GetById(item.IdSeries).Title;
            }
            return revBookDTO;
        }
    }
}
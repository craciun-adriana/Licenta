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

        public IEnumerable<ReviewSeriesDTO> GetByStatus(Status status)
        {
            return _reviewSeriesRepo.GetByStatus(status)
                 .Select(rb =>
                 {
                     var film = _seriesRepo.GetById(rb.IdSeries);
                     return new ReviewSeriesDTO
                     {
                         IdSeries = rb.IdSeries,
                         Director = film.Director,
                         Description = film.Description,
                         Genre = film.Genre,
                         Grade = rb.Grade,
                         IdReview = rb.ID,
                         IdUser = rb.IdUser,
                         PrequelID = film.PrequelID,
                         RelaseDate = film.RelaseDate,
                         Review = rb.Review,
                         SequelID = film.SequelID,
                         Status = rb.Status,
                         Title = film.Title,
                         Rating = film.Rating,
                         NrEps = film.NrEps
                     };
                 });
        }
    }
}
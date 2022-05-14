using LicentaAPI.AppServices.ReviewSerieses.Model;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;

namespace LicentaAPI.AppServices.ReviewSerieses
{
    /// <summary>
    /// Concrete implementation of <see cref="IReviewSeriesService"/>.
    /// </summary>
    public class ReviewSeriesService : IReviewSeriesService
    {
        private readonly IReviewSeriesRepo _reviewSeriesRepo;
        private readonly IMappingCoordinator _mapper;

        public ReviewSeriesService(IReviewSeriesRepo reviewSeriesRepo, IMappingCoordinator mapper)
        {
            _reviewSeriesRepo = reviewSeriesRepo;
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

        public IEnumerable<ReviewSeries> GetByStatus(Status status)
        {
            return _reviewSeriesRepo.GetByStatus(status);
        }
    }
}
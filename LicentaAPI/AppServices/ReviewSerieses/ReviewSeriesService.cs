using LicentaAPI.AppServices.ReviewSerieses.Model;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.AppServices.ReviewSerieses
{
    /// <summary>
    /// Concrete implemnetation of <see cref="IReviewSeriesService"/>.
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

        ///<inheritdoc/>
        public ReviewSeries CreateReviewSeries(ReviewSeriesCreate reviewSeriesCreate)
        {
            var reviewSeries = _mapper.Map<ReviewSeriesCreate, ReviewSeries>(reviewSeriesCreate);
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
    }
}
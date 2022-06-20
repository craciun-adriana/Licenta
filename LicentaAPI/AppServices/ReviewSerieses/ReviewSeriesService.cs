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
        private readonly IUserRepo _userRepo;
        private readonly IMappingCoordinator _mapper;

        public ReviewSeriesService(IReviewSeriesRepo reviewSeriesRepo, ISeriesRepo seriesRepo, IUserRepo userRepo, IMappingCoordinator mapper)
        {
            _reviewSeriesRepo = reviewSeriesRepo;
            _seriesRepo = seriesRepo;
            _userRepo = userRepo;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public ReviewSeries CreateOrUpdateReviewSeries(ReviewSeriesCreate reviewSeriesCreate)
        {
            var reviewSeries = _mapper.Map<ReviewSeriesCreate, ReviewSeries>(reviewSeriesCreate);
            var user = _userRepo.GetUserById(reviewSeries.IdUser);
            var existingReviewFilm = _reviewSeriesRepo.GetReviewSeriesByIdSeriesAndUser(reviewSeries.IdSeries, reviewSeries.IdUser);
            if (existingReviewFilm != null)
            {
                reviewSeries.ID = existingReviewFilm.ID;
                _reviewSeriesRepo.Update(reviewSeries);
                if (reviewSeries.Status == Status.Completed && existingReviewFilm.Status != Status.Completed)
                {
                    user.Rank++;
                }
                else if (reviewSeries.Status != Status.Completed && existingReviewFilm.Status == Status.Completed)
                {
                    user.Rank--;
                }
                _userRepo.Update(user);
                _reviewSeriesRepo.Update(reviewSeries);
            }
            else
            {
                reviewSeries.ID = Guid.NewGuid().ToString();
                try
                {
                    _reviewSeriesRepo.Add(reviewSeries);
                    if (reviewSeries.Status == Status.Completed)
                    {
                        user.Rank++;
                        _userRepo.Update(user);
                    }
                }
                catch (ArgumentNullException)
                {
                    return null;
                }
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
                         Series = series,
                         Grade = rb.Grade,
                         IdReview = rb.ID,
                         IdUser = rb.IdUser,
                         Review = rb.Review,
                         Status = rb.Status,
                     };
                 });
        }

        public IEnumerable<ReviewSeriesDTO> GetReviewSeriesByIdSeries(string idSeries)
        {
            return _reviewSeriesRepo.FindReviewSeriesByIdSeries(idSeries)
                 .Select(rb =>
                 {
                     var series = _seriesRepo.GetById(rb.IdSeries);
                     return new ReviewSeriesDTO
                     {
                         IdSeries = rb.IdSeries,
                         Series = series,
                         Grade = rb.Grade,
                         IdReview = rb.ID,
                         IdUser = rb.IdUser,
                         Username = _userRepo.GetUserById(rb.IdUser)?.UserName ?? "User deleted",
                         Review = rb.Review,
                         Status = rb.Status,
                     };
                 });
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
                item.Series = _seriesRepo.GetById(item.IdSeries);
            }
            return revBookDTO;
        }
    }
}
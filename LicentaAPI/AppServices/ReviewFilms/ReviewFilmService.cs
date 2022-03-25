using LicentaAPI.AppServices.ReviewFilms.Model;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.AppServices.ReviewFilms
{
    /// <summary>
    /// Concrete implementation of <see cref="IReviewFilmService"/>
    /// </summary>
    public class ReviewFilmService : IReviewFilmService
    {
        private readonly IReviewFilmRepo _reviewFilmRepo;
        private readonly IMappingCoordinator _mapper;

        public ReviewFilmService(IReviewFilmRepo reviewFilmRepo, IMappingCoordinator mapper)
        {
            _reviewFilmRepo = reviewFilmRepo;
            _mapper = mapper;
        }

        ///<inheritdoc/>
        public ReviewFilm CreateReviewFilm(ReviewFilmCreate reviewFilmCreate)
        {
            var reviewFilm = _mapper.Map<ReviewFilmCreate, ReviewFilm>(reviewFilmCreate);
            try
            {
                _reviewFilmRepo.Add(reviewFilm);
            }
            catch (ArgumentNullException)
            {
                return null;
            }

            return reviewFilm;
        }
    }
}
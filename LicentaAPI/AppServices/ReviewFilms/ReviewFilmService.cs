using LicentaAPI.AppServices.ReviewFilms.Model;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LicentaAPI.AppServices.ReviewFilms
{
    /// <summary>
    /// Concrete implementation of <see cref="IReviewFilmService"/>
    /// </summary>
    public class ReviewFilmService : IReviewFilmService
    {
        private readonly IReviewFilmRepo _reviewFilmRepo;
        private readonly IFilmRepo _filmRepo;
        private readonly IUserRepo _userRepo;
        private readonly IMappingCoordinator _mapper;

        public ReviewFilmService(IReviewFilmRepo reviewFilmRepo, IFilmRepo filmRepo, IUserRepo userRepo, IMappingCoordinator mapper)
        {
            _reviewFilmRepo = reviewFilmRepo;
            _filmRepo = filmRepo;
            _userRepo = userRepo;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public ReviewFilm CreateOrUpdateReviewFilm(ReviewFilmCreate reviewFilmCreate)
        {
            var reviewFilm = _mapper.Map<ReviewFilmCreate, ReviewFilm>(reviewFilmCreate);
            var user = _userRepo.GetUserById(reviewFilm.IdUser);
            var existingReviewFilm = _reviewFilmRepo.GetReviewFilmByIdFilmAndUser(reviewFilm.IdFilm, reviewFilm.IdUser);
            if (existingReviewFilm != null)
            {
                reviewFilm.ID = existingReviewFilm.ID;
                _reviewFilmRepo.Update(reviewFilm);
                if (reviewFilm.Status == Status.Completed && existingReviewFilm.Status != Status.Completed)
                {
                    user.Rank++;
                }
                else if (reviewFilm.Status != Status.Completed && existingReviewFilm.Status == Status.Completed)
                {
                    user.Rank--;
                }
                _userRepo.Update(user);
                _reviewFilmRepo.Update(reviewFilm);
            }
            else
            {
                reviewFilm.ID = Guid.NewGuid().ToString();
                try
                {
                    _reviewFilmRepo.Add(reviewFilm);
                    if (reviewFilm.Status == Status.Completed)
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

            return reviewFilm;
        }

        public IEnumerable<ReviewFilmDTO> GetByStatus(Status status, string idUser)
        {
            return _reviewFilmRepo.GetByStatus(status, idUser)
                .Select(rb =>
            {
                var film = _filmRepo.GetById(rb.IdFilm);
                return new ReviewFilmDTO
                {
                    IdFilm = rb.IdFilm,
                    Film = film,
                    Grade = rb.Grade,
                    IdReview = rb.ID,
                    IdUser = rb.IdUser,
                    Review = rb.Review,
                    Status = rb.Status,
                };
            });
        }

        public IEnumerable<ReviewFilmDTO> GetReviewFilmByIdFilm(string idFilm)
        {
            return _reviewFilmRepo.FindReviewFilmByIdFilm(idFilm)
                .Select(rb =>
                {
                    var film = _filmRepo.GetById(rb.IdFilm);
                    return new ReviewFilmDTO
                    {
                        IdFilm = rb.IdFilm,
                        Film = film,
                        Grade = rb.Grade,
                        IdReview = rb.ID,
                        IdUser = rb.IdUser,
                        Username = _userRepo.GetUserById(rb.IdUser)?.UserName ?? "User deleted",
                        Review = rb.Review,
                        Status = rb.Status,
                    };
                });
        }

        public ReviewFilm GetReviewFilmByIdFilmAndUser(string idFilm, string idUser)
        {
            return _reviewFilmRepo.GetReviewFilmByIdFilmAndUser(idFilm, idUser);
        }

        public IEnumerable<ReviewFilmDTO> GetReviewFilmCompletedByIdUser(string idUser)
        {
            var revFilms = _reviewFilmRepo.GetReviewFilmCompletedByIdUser(idUser);
            var revFilmDTO = _mapper.Map<ReviewFilm, ReviewFilmDTO>(revFilms);
            foreach (var item in revFilmDTO)
            {
                item.Film = _filmRepo.GetById(item.IdFilm);
            }
            return revFilmDTO;
        }
    }
}
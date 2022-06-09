﻿using LicentaAPI.AppServices.ReviewFilms.Model;
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
        private readonly IMappingCoordinator _mapper;

        public ReviewFilmService(IReviewFilmRepo reviewFilmRepo, IFilmRepo filmRepo, IMappingCoordinator mapper)
        {
            _reviewFilmRepo = reviewFilmRepo;
            _filmRepo = filmRepo;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public ReviewFilm CreateReviewFilm(ReviewFilmCreate reviewFilmCreate)
        {
            var reviewFilm = _mapper.Map<ReviewFilmCreate, ReviewFilm>(reviewFilmCreate);
            reviewFilm.ID = Guid.NewGuid().ToString();
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

        public IEnumerable<ReviewFilmDTO> GetByStatus(Status status, string idUser)
        {
            return _reviewFilmRepo.GetByStatus(status, idUser)
                .Select(rb =>
            {
                var film = _filmRepo.GetById(rb.IdFilm);
                return new ReviewFilmDTO
                {
                    IdFilm = rb.IdFilm,
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
                    Length = film.Length,
                    Picture = film.Picture
                };
            });
        }

        public IEnumerable<ReviewFilm> GetReviewFilmByIdFilm(string idFilm)
        {
            return _reviewFilmRepo.FindReviewFilmByIdFilm(idFilm);
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
                item.Title = _filmRepo.GetById(item.IdFilm).Title;
            }
            return revFilmDTO;
        }
    }
}
using LicentaAPI.AppServices.ReviewBooks.Model;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LicentaAPI.AppServices.ReviewBooks
{
    /// <summary>
    /// Concrete implementation of <see cref="IReviewBookService"/>.
    /// </summary>
    public class ReviewBookService : IReviewBookService
    {
        private readonly IReviewBookRepo _reviewBookRepo;
        private readonly IBookRepo _bookRepo;
        private readonly IUserRepo _userRepo;
        private readonly IMappingCoordinator _mapper;

        public ReviewBookService(IReviewBookRepo reviewBookRepo, IBookRepo bookRepo, IUserRepo userRepo, IMappingCoordinator mapper)
        {
            _reviewBookRepo = reviewBookRepo;
            _bookRepo = bookRepo;
            _userRepo = userRepo;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public ReviewBook CreateOrUpdateReviewBook(ReviewBookCreate reviewBookCreate)
        {
            var reviewBook = _mapper.Map<ReviewBookCreate, ReviewBook>(reviewBookCreate);
            var user = _userRepo.GetUserById(reviewBook.IdUser);
            var existingReviewBook = _reviewBookRepo.GetReviewBookByIdBookAndUser(reviewBook.IdBook, reviewBook.IdUser);
            if (existingReviewBook != null)
            {
                reviewBook.ID = existingReviewBook.ID;
                _reviewBookRepo.Update(reviewBook);
                if (reviewBook.Status == Status.Completed && existingReviewBook.Status != Status.Completed)
                {
                    user.Rank++;
                }
                else if (reviewBook.Status != Status.Completed && existingReviewBook.Status == Status.Completed)
                {
                    user.Rank--;
                }
                _userRepo.Update(user);
                _reviewBookRepo.Update(reviewBook);
            }
            else
            {
                reviewBook.ID = Guid.NewGuid().ToString();

                try
                {
                    _reviewBookRepo.Add(reviewBook);
                    if (reviewBook.Status == Status.Completed)
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

            return reviewBook;
        }

        public IEnumerable<ReviewBookDTO> GetByStatus(Status status, string idUser)
        {
            return _reviewBookRepo.GetByStatus(status, idUser)
                .Select(rb =>
                {
                    var book = _bookRepo.GetById(rb.IdBook);
                    return new ReviewBookDTO
                    {
                        IdBook = rb.IdBook,
                        Book = book,
                        Grade = rb.Grade,
                        IdReview = rb.ID,
                        IdUser = rb.IdUser,
                        Username = _userRepo.GetUserById(rb.IdUser).UserName,
                        Review = rb.Review,
                        Status = rb.Status,
                    };
                });
        }

        public IEnumerable<ReviewBookDTO> GetReviewBookByIdBook(string idBook)
        {
            return _reviewBookRepo.FindReviewBookByIdBook(idBook)
                .Select(rb =>
                {
                    var book = _bookRepo.GetById(rb.IdBook);
                    return new ReviewBookDTO
                    {
                        IdBook = rb.IdBook,
                        Book = book,
                        Grade = rb.Grade,
                        IdReview = rb.ID,
                        IdUser = rb.IdUser,
                        Username = _userRepo.GetUserById(rb.IdUser)?.UserName ?? "User deleted",
                        Review = rb.Review,
                        Status = rb.Status,
                    };
                });
        }

        public ReviewBook GetReviewBookByIdBookAndUser(string idBook, string idUser)
        {
            return _reviewBookRepo.GetReviewBookByIdBookAndUser(idBook, idUser);
        }

        public IEnumerable<ReviewBookDTO> GetReviewBookCompletedByIdUser(string idUser)
        {
            var revBooks = _reviewBookRepo.GetReviewBookCompletedByIdUser(idUser);
            var revBookDTO = _mapper.Map<ReviewBook, ReviewBookDTO>(revBooks);
            foreach (var item in revBookDTO)
            {
                item.Book = _bookRepo.GetById(item.IdBook);
            }
            return revBookDTO;
        }
    }
}
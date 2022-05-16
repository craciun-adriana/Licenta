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
        private readonly IMappingCoordinator _mapper;

        public ReviewBookService(IReviewBookRepo reviewBookRepo, IBookRepo bookRepo, IMappingCoordinator mapper)
        {
            _reviewBookRepo = reviewBookRepo;
            _bookRepo = bookRepo;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public ReviewBook CreateReviewBook(ReviewBookCreate reviewBookCreate)
        {
            var reviewBook = _mapper.Map<ReviewBookCreate, ReviewBook>(reviewBookCreate);
            reviewBook.ID = Guid.NewGuid().ToString();
            try
            {
                _reviewBookRepo.Add(reviewBook);
            }
            catch (ArgumentNullException)
            {
                return null;
            }

            return reviewBook;
        }

        public IEnumerable<ReviewBookDTO> GetByStatus(Status status)
        {
            return _reviewBookRepo.GetByStatus(status)
                .Select(rb =>
                {
                    var book = _bookRepo.GetById(rb.IdBook);
                    return new ReviewBookDTO
                    {
                        IdBook = rb.IdBook,
                        Author = book.Author,
                        Description = book.Description,
                        Genre = book.Genre,
                        Grade = rb.Grade,
                        IdReview = rb.ID,
                        IdUser = rb.IdUser,
                        PrequelID = book.PrequelID,
                        RelaseDate = book.RelaseDate,
                        Review = rb.Review,
                        SequelID = book.SequelID,
                        Status = rb.Status,
                        Title = book.Title,
                        Picture = book.Picture
                    };
                });
        }
    }
}
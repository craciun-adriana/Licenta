using LicentaAPI.AppServices.ReviewBooks.Model;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using System;

namespace LicentaAPI.AppServices.ReviewBooks
{
    /// <summary>
    /// Concrete implementation of <see cref="IReviewBookService"/>.
    /// </summary>
    public class ReviewBookService : IReviewBookService
    {
        private readonly IReviewBookRepo _reviewBookRepo;
        private readonly IMappingCoordinator _mapper;

        public ReviewBookService(IReviewBookRepo reviewBookRepo, IMappingCoordinator mapper)
        {
            _reviewBookRepo = reviewBookRepo;
            _mapper = mapper;
        }

        ///<inheritdoc/>
        public ReviewBook CreateReviewBook(ReviewBookCreate reviewBookCreate)
        {
            var reviewBook = _mapper.Map<ReviewBookCreate, ReviewBook>(reviewBookCreate);
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
    }
}
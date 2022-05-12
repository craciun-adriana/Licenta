using LicentaAPI.AppServices.ReviewBooks;
using LicentaAPI.AppServices.ReviewBooks.Model;
using LicentaAPI.Controllers.Models;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LicentaAPI.Controllers
{
    [ApiController]
    [Route("licenta/review-books")]
    public class ReviewBooksController : BaseController
    {
        private readonly IReviewBookService _reviewBooksService;
        private readonly IMappingCoordinator _mapper;

        public ReviewBooksController(IReviewBookService reviewBooksService, UserManager<AppUser> userManager, IMappingCoordinator mapper) : base(userManager)
        {
            _reviewBooksService = reviewBooksService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("create")]
        [SwaggerResponse(201, "ReviewBook was created.")]
        [SwaggerResponse(404, "ReviewBook can't be created.")]
        public IActionResult CreateReviewBooks(ReviewBooksCreateRequest request)
        {
            var reviewBookCreate = _mapper.Map<ReviewBooksCreateRequest, ReviewBookCreate>(request);
            var reviewBook = _reviewBooksService.CreateReviewBook(reviewBookCreate);

            if (reviewBook == null)
            {
                return CreateResponse(500, "DB error.");
            }
            return CreatedAtRoute("", new { reviewBook.ID }, reviewBook);
        }
    }
}
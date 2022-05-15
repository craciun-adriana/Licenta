using LicentaAPI.AppServices.ReviewFilms;
using LicentaAPI.AppServices.ReviewFilms.Model;
using LicentaAPI.Controllers.Models;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;

namespace LicentaAPI.Controllers
{
    [ApiController]
    [Route("licenta/review-films")]
    public class ReviewFilmsController : BaseController
    {
        private readonly IReviewFilmService _reviewFilmsService;
        private readonly IMappingCoordinator _mapper;

        public ReviewFilmsController(IReviewFilmService reviewFilmsService, UserManager<AppUser> userManager, IMappingCoordinator mapper) : base(userManager)
        {
            _reviewFilmsService = reviewFilmsService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("create")]
        [SwaggerResponse(201, "ReviewFilm was created.")]
        [SwaggerResponse(404, "ReviewFilm can't be created.")]
        public IActionResult CreateReviewBooks(ReviewFilmsCreateRequest request)
        {
            var reviewFilmsCreate = _mapper.Map<ReviewFilmsCreateRequest, ReviewFilmCreate>(request);
            reviewFilmsCreate.IdUser = _userManager.GetUserId(HttpContext.User);
            var reviewFilm = _reviewFilmsService.CreateReviewFilm(reviewFilmsCreate);

            if (reviewFilm == null)
            {
                return CreateResponse(500, "DB error.");
            }
            return CreatedAtRoute("", new { reviewFilm.ID }, reviewFilm);
        }

        [Authorize]
        [HttpGet("get-by-status/{status}")]
        [SwaggerResponse(200, "ReviewFilm with the given status.")]
        [SwaggerResponse(404, "ReviewFilm can't be found.")]
        public IActionResult GetReviewBookByStatus(Status status)
        {
            var reviewFilm = _reviewFilmsService.GetByStatus(status);
            
                return Ok(reviewFilm);
                       
        }
    }
}
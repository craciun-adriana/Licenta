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
        public IActionResult GetReviewFilmByStatus(Status status)
        {
            var reviewFilm = _reviewFilmsService.GetByStatus(status);

            return Ok(reviewFilm);
        }

        [Authorize]
        [HttpGet("get-completed-by-user/{idUser}")]
        [SwaggerResponse(200, "ReviewFilm with the given idUser and status completed.")]
        public IActionResult GetReviewFilmCompletedByIdUser(string idUser)
        {
            var reviewFilmsDTO = _reviewFilmsService.GetReviewFilmCompletedByIdUser(idUser);
            return Ok(reviewFilmsDTO);
        }

        [Authorize]
        [HttpGet("get-by-id-film/{idFilm}")]
        [SwaggerResponse(200, "ReviewFilm with the given idFilm.")]
        public IActionResult GetReviewFilmByIdFilm(string idFilm)
        {
            var reviewFilms = _reviewFilmsService.GetReviewFilmByIdFilm(idFilm);
            return Ok(reviewFilms);
        }

        [Authorize]
        [HttpGet("get-by-id-film-and-user/{idFilm}")]
        [SwaggerResponse(200, "ReviewFilm with the given idFilm for logged user.")]
        public IActionResult GetReviewFilmByIdFilmAndUser(string idFilm)
        {
            var idUser = _userManager.GetUserId(HttpContext.User);
            var reviewFilm = _reviewFilmsService.GetReviewFilmByIdFilmAndUser(idFilm, idUser);
            return Ok(reviewFilm);
        }
    }
}
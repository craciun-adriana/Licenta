using LicentaAPI.AppServices.Films;
using LicentaAPI.AppServices.Films.Models;
using LicentaAPI.Controllers.Models;
using LicentaAPI.Infrastructure.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LicentaAPI.Controllers
{
    [ApiController]
    [Route("licenta/film")]
    public class FilmController : ControllerBase
    {
        public readonly IFilmService _filmService;
        public readonly IMappingCoordinator _mapper;

        public FilmController(IFilmService filmService, IMappingCoordinator mapper)
        {
            _filmService = filmService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("create-film")]
        [SwaggerResponse(201, "Film was created.")]
        [SwaggerResponse(404, "Film can't be created.")]
        public IActionResult CreateFilm(FilmCreateRequest request)
        {
            var filmCreate = _mapper.Map<FilmCreateRequest, FilmCreate>(request);

            var film = _filmService.CreateFilm(filmCreate);
            if (film == null)
            {
                return CreateResponse(500, new { Error = "DB Error." });
            }

            return CreatedAtRoute("", new { film.ID }, film);
        }

        [Authorize]
        [HttpGet("get-all-films")]
        public IActionResult GetAllFilms()
        {
            return Ok(_filmService.GetAllFilms());
        }

        private IActionResult CreateResponse<T>(int statusCode, T content)
        {
            if (statusCode >= 400)
            {
                var errorResponse = BadRequest(content);
                errorResponse.StatusCode = statusCode;
                return errorResponse;
            }

            var response = Ok(content);
            response.StatusCode = statusCode;
            return response;
        }
    }
}
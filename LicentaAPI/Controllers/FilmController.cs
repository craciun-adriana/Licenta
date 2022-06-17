using LicentaAPI.AppServices.Films;
using LicentaAPI.AppServices.Films.Models;
using LicentaAPI.Controllers.Models;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace LicentaAPI.Controllers
{
    [ApiController]
    [Route("licenta/film")]
    public class FilmController : BaseController
    {
        public readonly IFilmService _filmService;
        public readonly IMappingCoordinator _mapper;

        public FilmController(IFilmService filmService, UserManager<AppUser> userManager, IMappingCoordinator mapper) : base(userManager)
        {
            _filmService = filmService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("create")]
        [SwaggerResponse(201, "Film was created.")]
        [SwaggerResponse(404, "Film can't be created.")]
        public async Task<IActionResult> CreateFilmAsync(FilmCreateRequest request)
        {
            if (!await UserIsAdminAsync())
            {
                return Unauthorized();
            }

            var filmCreate = _mapper.Map<FilmCreateRequest, FilmCreate>(request);
            var film = _filmService.CreateFilm(filmCreate);

            if (film == null)
            {
                return CreateResponse(500, new { Error = "DB Error." });
            }

            return CreatedAtRoute("", new { film.ID }, film);
        }

        [Authorize]
        [HttpGet("get-all")]
        [SwaggerResponse(200, "All the films from the database.")]
        public IActionResult GetAllFilms()
        {
            return Ok(_filmService.GetAllFilms());
        }

        [Authorize]
        [HttpGet("get/{id}")]
        [SwaggerResponse(200, "Film with the given id.")]
        [SwaggerResponse(404, "Film was not found.")]
        public IActionResult GetFilmById(string id)
        {
            var film = _filmService.GetFilmById(id);
            if (film != null)
            {
                return Ok(film);
            }
            return NotFound();
        }

        [Authorize]
        [HttpDelete("delete/{id}")]
        [SwaggerResponse(200, "Film with the given id was deleted.")]
        public IActionResult DeleteFilmById(string id)
        {
            _filmService.DeleteFilm(id);
            return Ok();
        }

        [Authorize]
        [HttpGet("find-by-title/{title}")]
        [SwaggerResponse(200, "Films with given string in title")]
        public IActionResult FindFilmsByTitle(string title)
        {
            return Ok(_filmService.FindFilmByTitle(title));
        }

        [Authorize]
        [HttpGet("find-by-genre/{genre}")]
        [SwaggerResponse(200, "Films with given genre")]
        public IActionResult FindFilmsByGenre(Genre genre)
        {
            return Ok(_filmService.FindFilmByGenre(genre));
        }

        [Authorize]
        [HttpPost("update")]
        public async Task<IActionResult> UpdateFilm(UpdateFilmRequest request)
        {
            if (!await UserIsAdminAsync())
            {
                return Unauthorized();
            }
            var filmUpdate = _mapper.Map<UpdateFilmRequest, FilmUpdate>(request);
            return Ok(_filmService.UpdateFilm(filmUpdate));
        }
    }
}
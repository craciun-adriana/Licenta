using LicentaAPI.AppServices.Serieses;
using LicentaAPI.AppServices.Serieses.Models;
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
    [Route("licenta/series")]
    public class SeriesController : BaseController
    {
        public readonly ISeriesService _seriesService;
        public readonly IMappingCoordinator _mapper;

        public SeriesController(ISeriesService seriesService, UserManager<AppUser> userManager, IMappingCoordinator mapper) : base(userManager)
        {
            _seriesService = seriesService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("create")]
        [SwaggerResponse(201, "Series was created.")]
        [SwaggerResponse(404, "Series can't be created.")]
        public async Task<IActionResult> CreateSeriesAsync(SeriesCreateRequest request)
        {
            if (!await UserIsAdminAsync())
            {
                return Unauthorized();
            }

            var seriesCreate = _mapper.Map<SeriesCreateRequest, SeriesCreate>(request);
            var series = _seriesService.CreateSeries(seriesCreate);

            if (series == null)
            {
                return CreateResponse(500, new { Error = "DB Error." });
            }

            return CreatedAtRoute("", new { series.ID }, series);
        }

        [Authorize]
        [HttpGet("get-all")]
        [SwaggerResponse(200, "All series from the database.")]
        public IActionResult GetAllSeries()
        {
            return Ok(_seriesService.GetAllSeries());
        }

        [Authorize]
        [HttpGet("get/{id}")]
        [SwaggerResponse(200, "Series with the given id.")]
        [SwaggerResponse(404, "Series was not found.")]
        public IActionResult GetSeriesById(string id)
        {
            var series = _seriesService.GetSeriesById(id);
            if (series != null)
            {
                return Ok(series);
            }
            return NotFound();
        }

        [Authorize]
        [HttpDelete("delete/{id}")]
        [SwaggerResponse(200, "Series with the given id was deleted.")]
        public IActionResult DeleteSeriesById(string id)
        {
            _seriesService.DeleteSeries(id);
            return Ok();
        }

        [Authorize]
        [HttpGet("find-by-title/{title}")]
        [SwaggerResponse(200, "Series with given string in title")]
        public IActionResult FindSeriesByTitle(string title)
        {
            return Ok(_seriesService.FindSeriesByTitle(title));
        }

        [Authorize]
        [HttpGet("find-by-genre/{genre}")]
        [SwaggerResponse(200, "Series with given genre")]
        public IActionResult FindSeriesByGenre(Genre genre)
        {
            return Ok(_seriesService.FindSeriesByGenre(genre));
        }
    }
}
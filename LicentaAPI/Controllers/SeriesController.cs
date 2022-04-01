﻿using LicentaAPI.AppServices.Serieses;
using LicentaAPI.AppServices.Serieses.Models;
using LicentaAPI.Controllers.Models;
using LicentaAPI.Infrastructure.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LicentaAPI.Controllers
{
    [ApiController]
    [Route("licenta/series")]
    public class SeriesController : ControllerBase
    {
        public readonly ISeriesService _seriesService;
        public readonly IMappingCoordinator _mapper;

        public SeriesController(ISeriesService seriesService, IMappingCoordinator mapper)
        {
            _seriesService = seriesService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("create-series")]
        [SwaggerResponse(201, "Series was created.")]
        [SwaggerResponse(404, "Series can't be created.")]
        public IActionResult CreateSeries(SeriesCreateRequest request)
        {
            var seriesCreate = _mapper.Map<SeriesCreateRequest, SeriesCreate>(request);
            var series = _seriesService.CreateSeries(seriesCreate);

            if (series == null)
            {
                return CreateResponse(500, new { Error = "DB Error." });
            }

            return CreatedAtRoute("", new { series.ID }, series);
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
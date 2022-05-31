﻿using LicentaAPI.AppServices.ReviewSerieses;
using LicentaAPI.AppServices.ReviewSerieses.Model;
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
    [Route("licenta/review-series")]
    public class ReviewSeriesController : BaseController
    {
        private readonly IReviewSeriesService _reviewSeriesService;
        private readonly IMappingCoordinator _mapper;

        public ReviewSeriesController(IReviewSeriesService reviewSeriesService, UserManager<AppUser> userManager, IMappingCoordinator mapper) : base(userManager)
        {
            _reviewSeriesService = reviewSeriesService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("create")]
        [SwaggerResponse(201, "ReviewSeries was created.")]
        [SwaggerResponse(404, "ReviewSeries can't be created.")]
        public IActionResult CreateReviewBooks(ReviewSeriesCreateRequest request)
        {
            var reviewSeriesCreate = _mapper.Map<ReviewSeriesCreateRequest, ReviewSeriesCreate>(request);
            reviewSeriesCreate.IdUser = _userManager.GetUserId(HttpContext.User);
            var reviewSeries = _reviewSeriesService.CreateReviewSeries(reviewSeriesCreate);

            if (reviewSeries == null)
            {
                return CreateResponse(500, "DB error.");
            }
            return CreatedAtRoute("", new { reviewSeries.ID }, reviewSeries);
        }

        [Authorize]
        [HttpGet("get-by-status/{status}")]
        [SwaggerResponse(200, "ReviewSeries with the given status.")]
        [SwaggerResponse(404, "ReviewSeries can't be found.")]
        public IActionResult GetReviewSeriesByStatus(Status status)
        {
            var reviewSeries = _reviewSeriesService.GetByStatus(status);
            return Ok(reviewSeries);
        }

        [Authorize]
        [HttpGet("get-by-id-series/{idSeries}")]
        [SwaggerResponse(200, "ReviewSeries with the given idSeries.")]
        public IActionResult GetReviewSeriesByIdSeries(string idSeries)
        {
            var reviewSeries = _reviewSeriesService.GetReviewSeriesByIdSeries(idSeries);
            return Ok(reviewSeries);
        }

        [Authorize]
        [HttpGet("get-by-id-series-and-user/{idSeries}")]
        [SwaggerResponse(200, "ReviewSeries with the given idSeries for logged user.")]
        public IActionResult GetReviewSeriesByIdSeriesAndUser(string idSeries)
        {
            var idUser = _userManager.GetUserId(HttpContext.User);
            var reviewSeries = _reviewSeriesService.GetReviewSeriesByIdSeriesAndUser(idSeries, idUser);
            return Ok(reviewSeries);
        }
    }
}
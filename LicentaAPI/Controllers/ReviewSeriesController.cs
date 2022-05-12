using LicentaAPI.AppServices.ReviewSerieses;
using LicentaAPI.AppServices.ReviewSerieses.Model;
using LicentaAPI.Controllers.Models;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var reviewSeries = _reviewSeriesService.CreateReviewSeries(reviewSeriesCreate);

            if (reviewSeries == null)
            {
                return CreateResponse(500, "DB error.");
            }
            return CreatedAtRoute("", new { reviewSeries.ID }, reviewSeries);
        }
    }
}
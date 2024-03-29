﻿using LicentaAPI.AppServices.ReviewBooks;
using LicentaAPI.AppServices.ReviewBooks.Model;
using LicentaAPI.Controllers.Models;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading.Tasks;

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
        [HttpPost("create-update")]
        [SwaggerResponse(201, "ReviewBook was created.")]
        [SwaggerResponse(404, "ReviewBook can't be created.")]
        public IActionResult CreateOrUpdateReviewBooks(ReviewCreateRequest request)
        {
            var reviewBookCreate = _mapper.Map<ReviewCreateRequest, ReviewBookCreate>(request);
            reviewBookCreate.IdUser = _userManager.GetUserId(HttpContext.User);
            var reviewBook = _reviewBooksService.CreateOrUpdateReviewBook(reviewBookCreate);

            if (reviewBook == null)
            {
                return CreateResponse(500, "DB error.");
            }
            return CreatedAtRoute("", new { reviewBook.ID }, reviewBook);
        }

        [Authorize]
        [HttpGet("get-by-status/{status}")]
        [SwaggerResponse(200, "ReviewBook with the given status.")]
        public IActionResult GetReviewBookByStatus(Status status)
        {
            var idUser = _userManager.GetUserId(HttpContext.User);
            var reviewBook = _reviewBooksService.GetByStatus(status, idUser);
            return Ok(reviewBook);
        }

        [Authorize]
        [HttpGet("get-by-status/{status}/{idUser}")]
        [SwaggerResponse(200, "ReviewBook with the given status.")]
        public IActionResult GetReviewBookByStatus(Status status, string idUser)
        {
            var reviewBook = _reviewBooksService.GetByStatus(status, idUser);
            return Ok(reviewBook);
        }

        [Authorize]
        [HttpGet("get-by-id-book/{idBook}")]
        [SwaggerResponse(200, "ReviewBook with the given idBook.")]
        public IActionResult GetReviewBookByIdBook(string idBook)
        {
            var reviewBooks = _reviewBooksService.GetReviewBookByIdBook(idBook);
            return Ok(reviewBooks);
        }

        [Authorize]
        [HttpGet("get-by-id-book-and-user/{idBook}")]
        [SwaggerResponse(200, "ReviewBook with the given idBook for logged user.")]
        public IActionResult GetReviewBookByIdBookAndUser(string idBook)
        {
            var idUser = _userManager.GetUserId(HttpContext.User);
            var reviewBook = _reviewBooksService.GetReviewBookByIdBookAndUser(idBook, idUser);
            return Ok(reviewBook);
        }

        [Authorize]
        [HttpDelete("delete/{idReview}")]
        public async Task<IActionResult> DeleteReview(string idReview)
        {
            if (await UserIsAdminAsync())
            {
                _reviewBooksService.DeleteReview(idReview);
                return Ok();
            }
            return Unauthorized();
        }
    }
}
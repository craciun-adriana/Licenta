using LicentaAPI.AppServices.Books;
using LicentaAPI.AppServices.Books.Models;
using LicentaAPI.Controllers.Models;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaAPI.Controllers
{
    [ApiController]
    [Route("licenta/book")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMappingCoordinator _mapper;

        public BookController(IBookService bookService, IMappingCoordinator mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("create-book")]
        [SwaggerResponse(201, "Book was created.")]
        [SwaggerResponse(404, "Book can't be created.")]
        public IActionResult CreateBook(BookCreateRequest request)
        {
            var bookCreate = _mapper.Map<BookCreateRequest, BookCreate>(request);

            var book = _bookService.CreateBook(bookCreate);

            if (book == null)
            {
                return CreateResponse(500, new { Error = "DB Error." });
            }

            return CreatedAtRoute("", new { book.ID }, book);
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
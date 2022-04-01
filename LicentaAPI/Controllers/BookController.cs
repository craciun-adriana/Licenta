using LicentaAPI.AppServices.Books;
using LicentaAPI.AppServices.Books.Models;
using LicentaAPI.Controllers.Models;
using LicentaAPI.Infrastructure.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        [HttpPost("create")]
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

        [Authorize]
        [HttpGet("get-all")]
        [SwaggerResponse(200, "All the book from the database.")]
        public IActionResult GetAllBooks()
        {
            return Ok(_bookService.GetAllBooks());
        }

        [Authorize]
        [HttpGet("get/{id}")]
        [SwaggerResponse(200, "Book with the given id.")]
        [SwaggerResponse(404, "Book was not fount .")]
        public IActionResult GetBookById(string id)
        {
            return Ok(_bookService.GetBookById(id));
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
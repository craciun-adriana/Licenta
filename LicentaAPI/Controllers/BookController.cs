using LicentaAPI.AppServices.Books;
using LicentaAPI.AppServices.Books.Models;
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
    [Route("licenta/book")]
    public class BookController : BaseController
    {
        private readonly IBookService _bookService;
        private readonly IMappingCoordinator _mapper;

        public BookController(IBookService bookService, UserManager<AppUser> userManager, IMappingCoordinator mapper) : base(userManager)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("create")]
        [SwaggerResponse(201, "Book was created.")]
        [SwaggerResponse(404, "Book can't be created.")]
        public async Task<IActionResult> CreateBookAsync(BookCreateRequest request)
        {
            if (!await UserIsAdminAsync())
            {
                return Unauthorized();
            }

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
        [SwaggerResponse(404, "Book was not found.")]
        public IActionResult GetBookById(string id)
        {
            var book = _bookService.GetBookById(id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }
    }
}
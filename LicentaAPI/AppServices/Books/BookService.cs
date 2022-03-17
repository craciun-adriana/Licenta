using LicentaAPI.AppServices.Books.Models;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using System;

namespace LicentaAPI.AppServices.Books
{
    /// <summary>
    /// Concrete implementation of <see cref="IBookService"/>.
    /// </summary>
    public class BookService : IBookService
    {
        private IBookRepo _bookRepo;
        private IMappingCoordinator _mapper;

        public BookService(IBookRepo bookRepo, IMappingCoordinator mapper)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;
        }

        ///<inheritdoc/>
        public Book CreateBook(BookCreate bookCreate)
        {
            var book = _mapper.Map<BookCreate, Book>(bookCreate);
            try
            {
                _bookRepo.Add(book);
            }
            catch (ArgumentNullException)
            {
                return null;
            }

            return book;
        }
    }
}
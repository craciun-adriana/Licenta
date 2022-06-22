using LicentaAPI.AppServices.Books.Models;
using LicentaAPI.Infrastructure.Mapper;
using LicentaAPI.Persistence.Models;
using LicentaAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;

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

        /// <inheritdoc/>
        public Book CreateBook(BookCreate bookCreate)
        {
            var book = _mapper.Map<BookCreate, Book>(bookCreate);
            book.ID = Guid.NewGuid().ToString();
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

        public BookDTO GetBookById(string idBook)
        {
            var book = _bookRepo.GetById(idBook);
            if (book == null)
            {
                return null;
            }
            var bookDTO = _mapper.Map<Book, BookDTO>(book);

            if (!string.IsNullOrEmpty(bookDTO.PrequelID))
            {
                bookDTO.PrequelTitle = _bookRepo.GetById(book.PrequelID).Title;
            }

            if (!string.IsNullOrEmpty(bookDTO.SequelID))
            {
                bookDTO.SequelTitle = _bookRepo.GetById(book.SequelID).Title;
            }

            return bookDTO;
        }

        public void DeleteBook(string idBook)
        {
            var bookDTO = GetBookById(idBook);
            var book = _mapper.Map<BookDTO, Book>(bookDTO);
            if (book != null)
            {
                _bookRepo.Delete(book);
            }
        }

        public IEnumerable<Book> FindBookByTitle(string title)
        {
            return _bookRepo.FindBookByTitle(title);
        }

        public BookUpdateResult UpdateBook(BookUpdate bookUpdate)
        {
            var book = _bookRepo.GetById(bookUpdate.ID);
            if (book == null)
            {
                return new BookUpdateResult
                {
                    Error = "Book not found.",
                    UpdatedBook = null
                };
            }
            _mapper.Map(bookUpdate, book);
            _bookRepo.Update(book);

            return new BookUpdateResult
            {
                Error = "",
                UpdatedBook = book
            };
        }

        /// <inheritdoc/>
        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepo.GetAll();
        }

        public IEnumerable<Book> FindBookByGenre(Genre genre)
        {
            return _bookRepo.FindBookByGenre(genre);
        }
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSOA.Auth;
using ProjectSOA.Dtos;
using ProjectSOA.Interfaces;
using ProjectSOA.Models;
using System.Text.Json;
using System.Security.Claims;

namespace ProjectSOA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<BookDto>>GetAllBooks()
        {
          
            var books = _bookRepository.GetBooks();

            var bookDtos = _mapper.Map<IEnumerable<BookDto>>(books);

            return Ok(bookDtos);
        }

        [HttpGet("SearchBook")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<BookDto>> SearchBook(int? minYear, int? maxYear, string? searchTerm, int pageNumber = 1, int pageSize = 5)
        {
            var result = _bookRepository.SearchBooks(minYear, maxYear, searchTerm, pageNumber, pageSize);

            if (!result.Books.Any())
                return NotFound();

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(result.PaginationMetadata));

            var booksDtos = _mapper.Map<IEnumerable<BookDto>>(result.Books);

            return Ok(booksDtos);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<BookDto> GetBookById(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
                return NotFound();
            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult CreateBook([FromBody] CreateBookDto createBookDto)
        {
            var book = _mapper.Map<Book>(createBookDto);

            if (book == null)
                return BadRequest();

            _bookRepository.CreateBook(book);
            _bookRepository.SaveChanges();
            return Created("BookUri", new { book.Title });
        }

        [HttpPut("{id}")]
   
        public ActionResult UpdateBook(int id, [FromBody] UpdateBookDto updateBookDto)
        {
            var book = _mapper.Map<Book>(updateBookDto);
            _bookRepository.UpdateBook(book);
            _bookRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public ActionResult DeleteBook(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
                return BadRequest();

            _bookRepository.DeleteBook(id);
            return Ok($"The book with id {id} is deleted");
        }
       

    }
}

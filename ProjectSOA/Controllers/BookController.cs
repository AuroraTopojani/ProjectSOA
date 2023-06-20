using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSOA.Dtos;
using ProjectSOA.Interfaces;
using ProjectSOA.Models;

namespace ProjectSOA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public ActionResult<IEnumerable<BookDto>>GetAllBooks()
        {
            var books = _bookRepository.GetBooks();

            if (!books.Any())
                return NotFound();
            var bookDtos = _mapper.Map<IEnumerable<BookDto>>(books);

            return Ok(bookDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<BookDto> GetBookById(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
                return NotFound();
            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(book);
        }

        [HttpPost]
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
        public ActionResult DeleteBook(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
                return BadRequest();

            _bookRepository.DeleteBook(id);
            return NoContent();
        }
      
       
    }
}

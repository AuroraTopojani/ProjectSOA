using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSOA.Interfaces;
using ProjectSOA.Models;

namespace ProjectSOA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>>GetAllBooks()
        {
            var books = _bookRepository.GetBooks();

            if (!books.Any())
                return NotFound();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public ActionResult CreateBook([FromBody] Book book)
        {
            if (book == null)
                return BadRequest();
            _bookRepository.CreateBook(book);
            return Created("BookUri", new { book.Title });
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, [FromBody] Book book)
        {
            var oldBook = _bookRepository.GetBookById(id);
            if (oldBook == null)
                return NotFound();
            _bookRepository.UpdateBook(book);
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

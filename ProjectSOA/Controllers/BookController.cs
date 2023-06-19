using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSOA.Models;

namespace ProjectSOA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            var books = new List<Book>()
            {
                new Book()
                        {
                            Title = "The Green Mile",
                            bId =1,
                            availability = true,
                            Genre ="Serial Novel",
                            Author = new Author
                            {
                                AId = 1,
                                Name= "Stephen",
                                Surname = "King",
                                Born = 1947
                            },
                            Written=1996
                        },
                       new Book()
                        {
                            Title = "Four Past Midnight",
                            bId =2,
                            availability = true,
                            Genre ="Mystery",
                            Author = new Author
                            {
                                AId = 1,
                                Name= "Stephen",
                                Surname = "King",
                                Born = 1947
                            },
                            Written=1990
                        },
                       new Book()
                        {
                            Title = "The Sun Also Rises",
                            bId =3,
                            availability = false,
                            Genre ="Roman à clef",
                             Author = new Author
                            {
                                AId = 2,
                                Name= "Ernest",
                                Surname = "Hemingway",
                                 Born = 1899
                            },
                            Written=1926
                        },
                       new Book()
                        {
                            Title = "Green Hills of Africa",
                            bId =4,
                            availability = true,
                            Genre ="nonfiction",
                            Author = new Author
                            {
                                AId = 2,
                                Name= "Ernest",
                                Surname = "Hemingway",
                                 Born = 1899
                            },
                            Written=1935
                        }
            };

            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetBookById(int id)
        {
            var book = "Some book";
            return Ok(book);
        }

        [HttpPost]
        public ActionResult CreateBook([FromBody] Book book)
        {
            var newBook = book;
            return Ok($"New book {book.Title} is created");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(int bId, [FromBody] string book)
        {
            return Ok($"The book {book} is updated");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int bId)
        {
            return Ok($"The book with id {bId} is deleted");
        }
    }
}

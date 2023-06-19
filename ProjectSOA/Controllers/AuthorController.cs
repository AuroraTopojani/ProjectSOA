using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSOA.Models;

namespace ProjectSOA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAllAuthors()
        {
            var authors = new List<Author>()
            {
                new Author()
                {
                    AId = 1,
                    Name= "Stephen",
                    Surname = "King",
                    Born = 1947
                },
                new Author()
                {
                    AId = 2,
                    Name= "Ernest",
                    Surname = "Hemingway",
                    Born = 1899
                   
                }
            };

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetAuthorById(int id)
        {
            var author = "Some author";
            return Ok(author);
        }

        [HttpPost]
        public ActionResult CreateAuthor([FromBody] Author author)
        {
            var newAuthor = author;
            return Ok($"New author {author.Name} is created");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAuthor(int AId, [FromBody] string author)
        {
            return Ok($"The author {author} is updated");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAuthor(int AId)
        {
            return Ok($"The author with id {AId} is deleted");
        }
    }
}

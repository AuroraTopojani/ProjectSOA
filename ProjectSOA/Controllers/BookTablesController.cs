using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSOA.Models;

namespace ProjectSOA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookTablesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<BookTable>> GetAllBookTables()
        {
            var BookTables = new List<BookTable>()
            {
                new BookTable()
                        {
                     tId=1,
                     tAvailability= true,
                    


                        }

            };

            return Ok(BookTables);
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetBookTableById(int tId)
        {
            var BookTable = "Some BookTable";
            return Ok(BookTable);
        }

        [HttpPost]
        public ActionResult CreateBookTable([FromBody] BookTable BookTable)
        {
            var newBookTable = BookTable;
            return Ok($"New BookTable {BookTable.tId} is created");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBookTable(int tId, [FromBody] string BookTable)
        {
            return Ok($"The BookTable {BookTable} is updated");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBookTable(int tId)
        {
            return Ok($"The BookTable with id {tId} is deleted");
        }
    }
}

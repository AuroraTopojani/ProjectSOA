using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSOA.Models;

namespace ProjectSOA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Table>> GetAllTables()
        {
            var tables = new List<Table>()
            {
                new Table()
                        {
                     tId=1,
                     tAvailability= true,
                    


                        }

            };

            return Ok(tables);
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetTableById(int tId)
        {
            var table = "Some table";
            return Ok(table);
        }

        [HttpPost]
        public ActionResult CreateTable([FromBody] Table table)
        {
            var newTable = table;
            return Ok($"New table {table.tId} is created");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTable(int tId, [FromBody] string table)
        {
            return Ok($"The table {table} is updated");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTable(int tId)
        {
            return Ok($"The table with id {tId} is deleted");
        }
    }
}

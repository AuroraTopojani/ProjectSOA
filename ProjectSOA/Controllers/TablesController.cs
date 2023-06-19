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
                     students = new List<Student>
                      {
                         
                  new Student {
                      Id=2,
                     Name= "Aurora",
                     Surame="Topojani",
                     Faculty=" CST",
                     Books = new List<Book>
                    {
                        new Book
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
                       new Book
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
                    }


                      },
                      new Student()
                        {
                     Id=1,
                     Name= "Sulejma",
                     Surame="Kurtishi",
                     Faculty=" CST",
                     Books = new List<Book>
                    {
                        new Book
                        {
                            Title = "The Green Mile",
                            bId =1,
                            availability = true,
                            Genre ="Serial Novel",
                             Author = new Author
                            {
                                AId = 2,
                                Name= "Ernest",
                                Surname = "Hemingway",
                                 Born = 1899
                            },
                            Written=1996
                        },
                       new Book
                        {
                            Title = "Four Past Midnight",
                            bId =2,
                            availability = true,
                            Genre ="Mystery",
                             Author = new Author
                            {
                                AId = 2,
                                Name= "Ernest",
                                Surname = "Hemingway",
                                 Born = 1899
                            },
                            Written=1990
                        }
                    } }


                     }


                       


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

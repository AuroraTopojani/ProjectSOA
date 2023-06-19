using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSOA.Models;

namespace ProjectSOA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            var students = new List<Student>()
            {
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
                    },
                Tables = new List<Table>()
                {
                    new Table
                    {
                        tId=1,
                        tAvailability=true
                    }
                }
                     


    },
                new Student()
                        {
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
                    },
                        Tables = new List<Table>()
                         {
                    new Table
                    {
                        tId=1,
                        tAvailability=true
                    }
                }
                }

            };

            return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetStudentById(int id)
        {
            var student = "Some student";
            return Ok(student);
        }

        [HttpPost]
        public ActionResult CreateStudent([FromBody]Student student)
        {
            var newStudent = student;
            return Ok($"New student {student.Name} is created");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, [FromBody] string student)
        {
            return Ok($"The student {student} is updated");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            return Ok($"The student with id {id} is deleted");
        }
    }
}

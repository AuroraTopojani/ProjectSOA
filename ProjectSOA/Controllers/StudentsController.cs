using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSOA.Interfaces;
using ProjectSOA.Models;

namespace ProjectSOA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {

            var students = _studentRepository.GetStudents();
            if (!students.Any())
                return NotFound();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetStudentById(int id)
        {
            var student = _studentRepository.GetStudentById(id);
            if(student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public ActionResult CreateStudent([FromBody]Student student)
        {
            if (student == null)
                return BadRequest();
            _studentRepository.CreateStudent(student);
            return Created("MovieUri", new { student.Name });
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            var oldStudent=_studentRepository.GetStudentById(id);
            if (oldStudent == null)
                return NotFound();
            _studentRepository.UpdateStudent(student);  

            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var student = _studentRepository.GetStudentById(id);
            if (student == null)
                return BadRequest();
            _studentRepository.DeleteStudent(id);
            return NoContent();
        }
    }
}

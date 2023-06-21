using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSOA.Dtos;
using ProjectSOA.Interfaces;
using ProjectSOA.Models;
using ProjectSOA.Repository;

namespace ProjectSOA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public StudentsController(IStudentRepository studentRepository, IMapper mapper )
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<StudentDto>> GetAllStudents()
        {

            var students = _studentRepository.GetStudents();
            //if (!students.Any())
                //return NotFound();
            var studentDtos = _mapper.Map<IEnumerable<StudentDto>>(students);

            return Ok(studentDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<StudentDto> GetStudentById(int id)
        {
            var student = _studentRepository.GetStudentById(id);
            if(student == null)
                return NotFound();

            var studentDto = _mapper.Map<StudentDto>(student);
            return Ok(studentDto);
        }

        [HttpPost]
        public ActionResult CreateStudent([FromBody]CreateStudentDto createStudentDto)
        {
            var student = _mapper.Map<Student>(createStudentDto);
            if (student == null)
                return BadRequest();
            _studentRepository.CreateStudent(student);
            _studentRepository.SaveChanges();
            return Created("BookUri", new { student.Name });
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, [FromBody] UpdateStudentDto updateStudentDto)
        {

            var student = _mapper.Map<Student>(updateStudentDto);
            _studentRepository.UpdateStudent(student);
            _studentRepository.SaveChanges();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var student = _studentRepository.GetStudentById(id);
            if (student == null)
                return BadRequest();
            _studentRepository.DeleteStudent(id);
            return Ok($"The student with id {id} is deleted");
        }

    }
}

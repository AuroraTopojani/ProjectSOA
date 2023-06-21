using Microsoft.EntityFrameworkCore;
using ProjectSOA.Data;
using ProjectSOA.Interfaces;
using ProjectSOA.Models;

namespace ProjectSOA.Repository
{
    public class StudentRepository : IStudentRepository

    {
 
            private readonly AppDbContext _context;
            public StudentRepository(AppDbContext context)
            {
                _context = context;
            }
            public IEnumerable<Student> GetStudents()
            {
                var students = _context.Students
                    .Include(s => s.Books)
                    .Include(s => s.BookTables)
                    .ToList();

                return students;
            }

            public Student GetStudentById(int id)
                {
                    var student = _context.Students.FirstOrDefault(x => x.Id == id);
                    return student;
                }

            public void CreateStudent(Student student)
            {
                _context.Students.Add(student);
            }

            public void UpdateStudent(Student student)
            {
                _context.Update(student);
                SaveChanges();
            }

        public void DeleteStudent(int id)
        {
            var student = _context.Students.Include(s => s.Books).FirstOrDefault(x => x.Id == id);

            // Delete associated books
            _context.RemoveRange(student.Books);

            // Delete the student
            _context.Remove(student);

          
        }


        public bool SaveChanges()
            {
                _context.SaveChanges();
                return true;
            }

   
    }
    }

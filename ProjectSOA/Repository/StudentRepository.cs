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
                var student = _context.Students.Include(x => x.Name).Include(x => x.Surname).ToList();
                return student;
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
                var student = _context.Students.FirstOrDefault(x => x.Id == id);
                _context.Remove(student);
                SaveChanges();
            }

            public bool SaveChanges()
            {
                _context.SaveChanges();
                return true;
            }

   
    }
    }

using ProjectSOA.Models;

namespace ProjectSOA.Interfaces
{
    public interface IStudentRepository
    {
        public bool SaveChanges();
        public IEnumerable<Student> GetStudents();
        public Student GetStudentById(int id);
        public void CreateStudent(Student student);
        public void UpdateStudent(Student student);
        public void DeleteStudent(int id);
    }
}

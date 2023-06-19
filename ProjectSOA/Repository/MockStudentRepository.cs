using ProjectSOA.Interfaces;
using ProjectSOA.Models;

namespace ProjectSOA.Repository
{
    public class MockStudentRepository: IStudentRepository

    {
        private List<Student> _students;

        public MockStudentRepository()
        {
            _students = new List<Student>()
            {
                 new Student()
                  {
                     Id=1,
                     Name= "Sulejma",
                     Surname="Kurtishi",
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
                     Surname="Topojani",
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
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }

        public Student GetStudentById(int id)
        {
            var student = _students.Where(x => x.Id == id).First();
            return student;
        }

        public void CreateStudent(Student student)
        {
            _students.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            var updatedStudent = _students.Where(x => x.Id == student.Id).First();
            updatedStudent.Name = student.Name;
            updatedStudent.Faculty =student.Faculty;
        }

        public void DeleteStudent(int id)
        {
            var student = _students.Where(x => x.Id == id).First();
            _students.Remove(student);
        }

        public bool SaveChanges()
        {
            //Do nothing
            return true;
        }

       
    }
}

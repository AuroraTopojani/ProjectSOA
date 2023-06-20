using ProjectSOA.Models;

namespace ProjectSOA.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Faculty { get; set; }
        public ICollection<Book> Books { get; set; }

        public ICollection<Table> Tables { get; set; }

    }
}

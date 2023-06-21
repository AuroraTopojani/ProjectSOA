

using System.ComponentModel.DataAnnotations;

namespace ProjectSOA.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Faculty { get; set; }
        public ICollection<Book> Books { get; set; }

        public ICollection<BookTable> BookTables { get; set; }
    }
}

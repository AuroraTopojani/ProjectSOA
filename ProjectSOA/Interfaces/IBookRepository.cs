using ProjectSOA.Models;

namespace ProjectSOA.Interfaces
{
    public interface IBookRepository
    {
        public bool SaveChanges();
        public IEnumerable<Book> GetBooks();
        public Book GetBookById(int id);
        public void CreateBook(Book book);
        public void UpdateBook(Book book);
        public void DeleteBook(int id);
    }
}

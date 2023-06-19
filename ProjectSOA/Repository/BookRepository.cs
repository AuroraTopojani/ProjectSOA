using ProjectSOA.Interfaces;
using ProjectSOA.Models;

namespace ProjectSOA.Repository
{
    public class BookRepository: IBookRepository

    {
        public IEnumerable<Book> GetBooks()
        {
            throw new NotImplementedException();
        }

        public Book GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        
    }
}

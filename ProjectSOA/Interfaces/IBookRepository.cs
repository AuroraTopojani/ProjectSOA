using ProjectSOA.Models;
using ProjectSOA.Services;

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

        public (IEnumerable<Book> Books, PaginationMetadata PaginationMetadata) SearchBooks(int? minYear, int? maxYear, string? searchTerm , int pageNumber, int pageSize);
    }
}

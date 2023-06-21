using Microsoft.EntityFrameworkCore;
using ProjectSOA.Data;
using ProjectSOA.Interfaces;
using ProjectSOA.Models;
using ProjectSOA.Services;

namespace ProjectSOA.Repository
{
   
        public class BookRepository : IBookRepository

        {
            private readonly AppDbContext _context;
            public BookRepository(AppDbContext context)
            {
                _context = context;
            }
            public IEnumerable<Book> GetBooks()
            {
                var books = _context.Books
                    .Include(b => b.Author)
                    .ToList();

                return books;
            }
        public (IEnumerable<Book>, PaginationMetadata) SearchBooks(int? minYear, int? maxYear, string? searchTerm, int pageNumber, int pageSize)
        {
            var books = _context.Books as IQueryable<Book>;

            if (minYear != null)
            {
                books = books.Where(b => b.Written > minYear);
            }

            if (maxYear != null)
            {
                books = books.Where(b=> b.Written < maxYear);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                books = books.Where(b => b.Title.Contains(searchTerm) || b.Genre.Contains(searchTerm));
            }

       

            var totalItemCount = books.Count();

            var paginationMetadata = new PaginationMetadata(
                totalItemCount, pageSize, pageNumber);

            books = books
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize);

            return (books.ToList(), paginationMetadata);
        }

   

        public Book GetBookById(int id)
            {
                var book = _context.Books.FirstOrDefault(x => x.bId == id);
                return book;
            }

            public void CreateBook(Book book)
            {
                _context.Books.Add(book);
            }

            public void UpdateBook(Book book)
            {
                _context.Update(book);
                SaveChanges();
            }

            public void DeleteBook(int id)
            {
                var book = _context.Books.FirstOrDefault(x => x.bId == id);
                _context.Remove(book);
                SaveChanges();
            }

            public bool SaveChanges()
            {
                _context.SaveChanges();
                return true;
            }


        }
 }


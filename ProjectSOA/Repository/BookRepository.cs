using Microsoft.EntityFrameworkCore;
using ProjectSOA.Data;
using ProjectSOA.Interfaces;
using ProjectSOA.Models;

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
                var book = _context.Books.Include(x => x.Title).Include(x => x.Genre).ToList();
                return book;
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


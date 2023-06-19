using ProjectSOA.Interfaces;
using ProjectSOA.Models;

namespace ProjectSOA.Repository
{
    public class MockBookRepository : IBookRepository

    {
        private List<Book> _books;

        public MockBookRepository()
        {
            _books = new List<Book>()
            {
                 new Book()
                        {
                            Title = "The Green Mile",
                            bId =1,
                            availability = true,
                            Genre ="Serial Novel",
                            Author = new Author
                            {
                                AId = 1,
                                Name= "Stephen",
                                Surname = "King",
                                Born = 1947
                            },
                            Written=1996
                        },
                       new Book()
                        {
                            Title = "Four Past Midnight",
                            bId =2,
                            availability = true,
                            Genre ="Mystery",
                            Author = new Author
                            {
                                AId = 1,
                                Name= "Stephen",
                                Surname = "King",
                                Born = 1947
                            },
                            Written=1990
                        },
                       new Book()
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
                       new Book()
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

            };
        }

        public IEnumerable<Book> GetBooks()
        {
            return _books;
        }

        public Book GetBookById(int id)
        {
            var book = _books.Where(x => x.bId == id).First();
            return book;
        }

        public void CreateBook(Book book)
        {
            _books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            var updatedBook = _books.Where(x => x.bId == book.bId).First();
            updatedBook.Title = book.Title;
            updatedBook.Author =book.Author;
        }

        public void DeleteBook(int id)
        {
            var book = _books.Where(x => x.bId == id).First();
            _books.Remove(book);
        }

        public bool SaveChanges()
        {
            //Do nothing
            return true;
        }


    }
}


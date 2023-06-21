
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectSOA.Controllers;
using ProjectSOA.Dtos;
using ProjectSOA.Interfaces;
using ProjectSOA.Models;
using ProjectSOA.Profiles;

namespace ProjectSOA.Test
{
    public class BookControllerTests
    {
        private Mock<IBookRepository> _bookRepo;
        private IMapper _mapper;
        public BookControllerTests()
        {
            //Arrange 
            _bookRepo = new Mock<IBookRepository>();
            var bookProfile = new BookProfile();
            var configuration = new MapperConfiguration(cfg =>
               cfg.AddProfile(bookProfile));
            _mapper = new Mapper(configuration);

        }

        [Fact]
        public void GetAllBooks_ReturnZeroItems_WhenNoItemsInDb()
        {
            _bookRepo.Setup(repo => repo.GetBooks()).Returns(new List<Book>());
            var controller = new BookController(_bookRepo.Object, _mapper);

            //Act
            var result = controller.GetAllBooks();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

     

        [Fact]
        public void GetAllBooks_ReturnOneItem_WhenOneItemInDb()
        {
            _bookRepo.Setup(repo => repo.GetBooks()).Returns(new List<Book>()
            {
                new Book()
                {
                    bId = 1,
                    Title = "title",
                    Genre = "desc"
                }
            });

            var controller = new BookController(_bookRepo.Object, _mapper);

            //Act
            var result = controller.GetAllBooks();

            var okResult = result.Result as OkObjectResult;

            var books = okResult.Value as IEnumerable<BookDto>;
            //Assert 
            Assert.Single(books);
        }


        [Fact]
        public void GetbookById_ReturnsNotFound_WhenNonExistingIdIsAdded()
        {
            _bookRepo.Setup(repo => repo.GetBookById(1)).Returns(new Book()
            {
                bId = 1,
                Title = "The Green Mile"
            });
            var controller = new BookController(_bookRepo.Object, _mapper);


            //Act
            var result = controller.GetBookById(2);

            //Assert 
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetbookById_ReturnsCorrectDtoType_WhenExistingIdIsAdded()
        {
            _bookRepo.Setup(repo => repo.GetBookById(1)).Returns(new Book()
            {
                bId = 1,
                Title = "The Green Mile"
            });
            var controller = new BookController(_bookRepo.Object, _mapper);


            //Act
            var result = controller.GetBookById(1);

            var okResult = result.Result as OkObjectResult;

            var bookDto = okResult.Value as BookDto;

            //Assert 
            Assert.IsType<BookDto>(bookDto);
        }

        [Fact]
        public void GetbookById_ReturnsCorrectTitle_WhenExistingIdIsAsked()
        {
            var book = new Book()
            {
                bId = 1,
                Title = "The Green Mile"
            };

            _bookRepo.Setup(repo => repo.GetBookById(1)).Returns(book);
            var controller = new BookController(_bookRepo.Object, _mapper);


            //Act
            var result = controller.GetBookById(1);

            var okResult = result.Result as OkObjectResult;

            var bookDto = okResult.Value as BookDto;

            //Assert 
            Assert.Equal(book.Title, bookDto.Title);
        }


    }
}

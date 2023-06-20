using AutoMapper;
using ProjectSOA.Dtos;
using ProjectSOA.Models;

namespace ProjectSOA.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();
        }
    }
}

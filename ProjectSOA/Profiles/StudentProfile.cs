using AutoMapper;
using ProjectSOA.Dtos;
using ProjectSOA.Models;

namespace ProjectSOA.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<CreateStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>();
        }
    }
}


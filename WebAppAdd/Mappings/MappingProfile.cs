using AutoMapper;
using WebAppAdd.DTOs.SchoolDTOs;
using WebAppAdd.DTOs.StudentDTOs;
using WebAppAdd.Entities;

namespace WebAppAdd.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<School, SchoolGetDTO>();

            CreateMap<Student, StudentUpdateDTO>().ForMember(dest => dest.Name, opr => opr.MapFrom(src => src.School.Name)).ReverseMap();

            CreateMap<SchoolGetDTO, School>().ReverseMap();
            CreateMap<StudentUpdateDTO, Student>().ReverseMap();
        }
    }
}

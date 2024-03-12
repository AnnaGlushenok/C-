using AutoMapper;
using BLL.DTO;
using DAL.Models;

namespace BLL.Profiles;
public class StudentProfile : Profile {
	public StudentProfile() => CreateMap<Student, StudentDTO>().ReverseMap();
}

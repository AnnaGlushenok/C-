using AutoMapper;
using BLL.DTO;
using DAL.Models;

namespace BLL.Profiles;
public class MarkProfile : Profile {
	public MarkProfile() => CreateMap<Mark, MarkDTO>()
		.ForMember(dest => dest.Subject, opt => opt.MapFrom(src => new SubjectDTO { Id = src.Subject.Id, Name = src.Subject.Name }))
		.ForMember(dest => dest.Student, opt => opt.MapFrom(src => new StudentDTO { Id = src.Student.Id, Surname = src.Student.Surname, Name = src.Student.Name, Patronymic = src.Student.Patronymic }))
		.ReverseMap();
}

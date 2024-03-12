using AutoMapper;
using BLL.DTO;
using DAL.Models;

namespace BLL.Profiles;
public class SubjectProfile : Profile {
    public SubjectProfile() => CreateMap<Subject, SubjectDTO>().ReverseMap();
}

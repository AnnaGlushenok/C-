using AutoMapper;
using BLL.DTO;
using BLL.Profiles;
using DAL.Models;

namespace BLL.Services;
public class StudentService : IService<StudentDTO> {
	IRepository<Student> repository;
	IMapper mapper = new MapperConfiguration(mc => mc.AddProfile(new StudentProfile())).CreateMapper();

	public StudentService(IRepository<Student> repo) =>
	   repository = repo;

	public void Add(StudentDTO obj) =>
		repository.Add(mapper.Map<Student>(obj));

	public void Delete(int id) =>
		repository.Delete(id);

	public List<StudentDTO> FindAll() =>
		mapper.Map<List<StudentDTO>>(repository.FindAll());

	public void Update(StudentDTO obj) =>
		repository.Update(mapper.Map<Student>(obj));
}

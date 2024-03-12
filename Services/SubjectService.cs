using AutoMapper;
using BLL.DTO;
using BLL.Profiles;
using DAL.Models;

namespace BLL.Services;
public class SubjectService : IService<SubjectDTO> {
	IRepository<Subject> repository;
	IMapper mapper = new MapperConfiguration(mc => mc.AddProfile(new SubjectProfile())).CreateMapper();
	public SubjectService(IRepository<Subject> repo) =>
		repository = repo;

	public void Add(SubjectDTO obj) =>
		repository.Add(mapper.Map<Subject>(obj));

	public List<SubjectDTO> FindAll() =>
	   mapper.Map<List<SubjectDTO>>(repository.FindAll());

	public void Update(SubjectDTO obj) =>
		repository.Update(mapper.Map<Subject>(obj));

	public void Delete(int id) =>
		repository.Delete(id);
}

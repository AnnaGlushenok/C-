using AutoMapper;
using BLL.DTO;
using BLL.Profiles;
using DAL.Models;

namespace BLL.Services;
public class MarkService : IService<MarkDTO> {
	IRepository<Mark> repository;
	IMapper mapper = new MapperConfiguration(mc => mc.AddProfile(new MarkProfile())).CreateMapper();

	public MarkService(IRepository<Mark> repo) =>
		repository = repo;

	public void Add(MarkDTO obj) =>
		repository.Add(mapper.Map<Mark>(obj));

	public void Delete(int id) =>
		repository.Delete(id);

	public List<MarkDTO> FindAll() =>
		mapper.Map<List<MarkDTO>>(repository.FindAll());

	public void Update(MarkDTO obj) =>
		repository.Update(mapper.Map<Mark>(obj));
}

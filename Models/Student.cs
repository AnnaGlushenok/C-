namespace DAL.Models;
public class Student {
	public int Id { get; set; }
	public string Surname { get; set; }
	public string Name { get; set; }
	public string Patronymic { get; set; }
	public List<Mark> Marks { get; set; }
}

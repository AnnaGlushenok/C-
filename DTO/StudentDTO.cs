namespace BLL.DTO;
public class StudentDTO {
	public int Id { get; set; }
	public string Surname { get; set; }
	public string Name { get; set; }
	public string Patronymic { get; set; }
	public string FullName { get => Surname + " " + Name + " " + Patronymic; }
	//public override string ToString() => Surname + " " + Name + " " + Patronymic;
}

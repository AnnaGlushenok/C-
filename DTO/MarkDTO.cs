namespace BLL.DTO;
public class MarkDTO {
	public int Id { get; set; }
	public int StudentId { get; set; }
	public int SubjectId { get; set; }
	public int Score { get; set; }
	public String Date { get; set; }
	public StudentDTO Student { get; set; }
	public SubjectDTO Subject { get; set; }
}

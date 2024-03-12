using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Services;
internal class MarkRepository : IRepository<Mark> {

	private DatabaseContext db;
	public MarkRepository(DatabaseContext db) => this.db = db;
	public void Add(Mark obj) {
		bool isExist = db.Marks.Any(el => el.StudentId == obj.StudentId &&
												el.SubjectId == obj.SubjectId &&
												el.Score == obj.Score &&
												el.Date == obj.Date);
		if (!isExist) {
			db.Marks.Add(obj);
			db.SaveChanges();
		}
	}

	public void Delete(int id) {
		Mark mark = db.Marks.FirstOrDefault(s => s.Id == id);
		db.Marks.Remove(mark);
		db.SaveChanges();
	}

	public List<Mark> FindAll() =>
		 db.Marks.Include(mark => mark.Subject).Include(mark => mark.Student).ToList();

	public void Update(Mark obj) {
		Mark mark = db.Marks.FirstOrDefault(s => s.Id == obj.Id);
		if (mark == null)
			return;
		mark.Id = obj.Id;
		mark.SubjectId = obj.SubjectId;
		mark.StudentId = obj.StudentId;
		mark.Score = obj.Score;
		mark.Date = obj.Date;
		db.SaveChanges();
	}
}
